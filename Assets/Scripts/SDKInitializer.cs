using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SDKInitializer : MonoBehaviour
{
    private const string SceneMenuName = "Menu";

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexGamesSdk.CallbackLogging = true;
#endif
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialize);
    }

    private void OnInitialize()
    {
        SceneManager.LoadScene(SceneMenuName);
    }
}
