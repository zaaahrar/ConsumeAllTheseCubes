using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private AuthorizationOfferView _authorizationOfferView;
    [SerializeField] private AuthorizationErrorView _authorizationErrorView;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    private void Awake() => _openButton.onClick.AddListener(OnOpenButtonClick);
    private void OnDestroy() => _openButton.onClick.RemoveListener(OnOpenButtonClick);

    private void OpenLeaderboard()
    {
        Agava.YandexGames.Leaderboard.GetEntries(
            LeaderboardConstants.LEADERBOARD_NAME,
            result =>
            {
                List<LeaderboardEntryData> entries = new();

                foreach (Agava.YandexGames.LeaderboardEntryResponse entry in result.entries)
                    entries.Add(new LeaderboardEntryData(entry));

                _leaderboardView.ConstructEntries(entries);
            },
            topPlayersCount: 10);

        _leaderboardView.Show();
    }

    private void OnOpenButtonClick()
    {
        _audioFeedback.PlaySoundClick();

        if (Agava.YandexGames.PlayerAccount.IsAuthorized)
        {
            OpenLeaderboard();
            return;
        }

        void onAuthorizeSuccess() =>
            Agava.YandexGames.Utility.PlayerPrefs.Load(
                () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));

        void onAuthorizeError() => _authorizationErrorView.Show();

        _authorizationOfferView.Show(onAuthorizeSuccess, onAuthorizeError);
    }
}
