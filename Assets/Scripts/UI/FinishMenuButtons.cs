using UnityEngine;

public class FinishMenuButtons : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;

    public void ResetLevel() => _sceneChanger.LoadGameScene();

    public void ExitMenu() => _sceneChanger.LoadMenuScene();
}
