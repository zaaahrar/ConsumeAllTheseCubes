using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    private const int One = 1;

    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    [SerializeField] private TMP_Text _pageCounterText;

    [SerializeField] private int _totalLevel = 0;
    [SerializeField] private int _unLockedLevel = 1;

    private LevelButton[] _levelButtons;
    private int _totalPage = 0;
    private int _page = 0;
    private int _pageItem = 10;

    private void Awake() => _levelButtons = GetComponentsInChildren<LevelButton>();

    private void Start()
    {
        CheckLevels();
    }

    public void ClickNext()
    {
        _audioFeedback.PlaySoundClick();
        _page++;
        HideAllStars();
        Refresh();
    }

    public void ClickBack()
    {
        _audioFeedback.PlaySoundClick();
        _page--;
        HideAllStars();
        Refresh();
    }

    public void StartLevel(int level)
    {
        _audioFeedback.PlaySoundClick();
        _sceneChanger.LoadGameScene();
    }

    public void CheckLevels()
    {
        for(int i = 0; i < _levelButtons.Length; i++)
        {
            bool isPassed = PlayerPrefs.GetInt("Level" + (i + One)) == 1;

            if (isPassed)
            {
                _unLockedLevel++;
            }

            Refresh();
        }
    }

    public void Refresh()
    {
        _totalPage = _totalLevel / _pageItem;
        _totalPage--;
        int index = _page * _pageItem;

        for(int i = 0; i < _levelButtons.Length; i++)
        {
            int level = index + i + One;
            
            if (level <= _totalLevel)
            {
                _levelButtons[i].gameObject.SetActive(true);
                _levelButtons[i].Setup(level, level <= _unLockedLevel);
            }
            else
            {
                _levelButtons[i].gameObject.SetActive(false);
            }
        }

        _pageCounterText.text = $"{_page + One}/{_totalPage + One}";

        CheckButton();
    }

    private void CheckButton()
    {
        _backButton.gameObject.SetActive(_page > 0);
        _nextButton.gameObject.SetActive(_page < _totalPage);
    }

    private void HideAllStars()
    {
        Debug.Log("Hide!!");

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].HideStars();
        }
    }
}
