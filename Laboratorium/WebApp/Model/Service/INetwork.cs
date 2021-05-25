namespace Model.Service
{
    using Data;

    public interface INetwork
    {
        MatchData[] GetMatches();
    }
}