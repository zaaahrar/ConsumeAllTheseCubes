using TMPro;
using UnityEngine;

internal class LeaderboardEntryView : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void Initialize(LeaderboardEntryData entryData)
    {
        _rank.text = entryData.Rank.ToString();
        _name.text = entryData.Name;
        _score.text = entryData.Score.ToString();
    }
}
