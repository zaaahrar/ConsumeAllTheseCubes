using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private const int MenuSceneIndex = 0;
    private const int GameSceneIndex = 1;
    private const int PixelArtSceneIndex = 2;

    public void LoadMenuScene() => SceneManager.LoadScene(MenuSceneIndex);

    public void LoadGameScene() => SceneManager.LoadScene(GameSceneIndex);

    public void LoadPixelArtScene() => SceneManager.LoadScene(PixelArtSceneIndex);
}
