internal struct LeaderboardEntryData
{
    public LeaderboardEntryData(Agava.YandexGames.LeaderboardEntryResponse entry)
    {
        Rank = entry.rank;
        Name = entry.player.publicName;
        Score = entry.score;

        if (string.IsNullOrEmpty(Name))
            Name = LeaderboardConstants.ANONYMOUS_NAME;
    }

    public int Rank { get; }
    public string Name { get; }
    public int Score { get; }
}
