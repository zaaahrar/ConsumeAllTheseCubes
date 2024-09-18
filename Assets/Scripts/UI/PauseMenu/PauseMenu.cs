using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private PauseMenuView _menuView;

    private void OnEnable()
    {
        _menuView.OnExitingMenu += ExitMenu;
        _menuView.OnResetingLevel += ResetLevel;
    }

    private void OnDisable()
    {
        _menuView.OnExitingMenu -= ExitMenu;
        _menuView.OnResetingLevel -= ResetLevel;
    }

    public void ExitMenu()
    {
        Time.timeScale = 1;
        _sceneChanger.LoadMenuScene();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        _sceneChanger.LoadGameScene();
    }
}
