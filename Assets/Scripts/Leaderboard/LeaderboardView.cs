using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _mainContainer;
    [SerializeField] private Transform _playerEntryContainer;
    [SerializeField] private Button _closeButton;
    [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;
    [SerializeField] private LeaderboardEntryView _leaderboard1stEntryViewPrefab;
    [SerializeField] private LeaderboardEntryView _leaderboard2stEntryViewPrefab;
    [SerializeField] private LeaderboardEntryView _leaderboard3stEntryViewPrefab;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    private List<LeaderboardEntryView> _leaderboardEntryViewInstances = new();

    private void Awake() => _closeButton.onClick.AddListener(Hide);
    private void OnDestroy() => _closeButton.onClick.RemoveListener(Hide);

    public void ConstructEntries(List<LeaderboardEntryData> entryDatas)
    {
        ClearEntries();

        foreach (LeaderboardEntryData entryData in entryDatas)
            _leaderboardEntryViewInstances.Add(CreateEntryView(entryData));
    }

    public void Show() => gameObject.SetActive(true);
    private void Hide()
    {
        _audioFeedback.PlaySoundClick();
        gameObject.SetActive(false);
    }

    private LeaderboardEntryView CreateEntryView(LeaderboardEntryData entryData)
    {
        if (entryData.Rank == 1)
        {
            LeaderboardEntryView entryView = Instantiate(_leaderboard1stEntryViewPrefab, _mainContainer);
            entryView.Initialize(entryData);
            return entryView;
        }
        else if (entryData.Rank == 2)
        {
            LeaderboardEntryView entryView = Instantiate(_leaderboard2stEntryViewPrefab, _mainContainer);
            entryView.Initialize(entryData);
            return entryView;
        }
        else if (entryData.Rank == 3)
        {
            LeaderboardEntryView entryView = Instantiate(_leaderboard3stEntryViewPrefab, _mainContainer);
            entryView.Initialize(entryData);
            return entryView;
        }
        else
        {
            LeaderboardEntryView entryView = Instantiate(_leaderboardEntryViewPrefab, _mainContainer);
            entryView.Initialize(entryData);
            return entryView;
        }
    }

    private void ClearEntries()
    {
        foreach (LeaderboardEntryView leaderboardEntryView in _leaderboardEntryViewInstances)
            Destroy(leaderboardEntryView.gameObject);

        _leaderboardEntryViewInstances.Clear();
    }
}
