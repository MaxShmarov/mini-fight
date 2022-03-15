using MiniFight.Interfaces;

namespace MiniFight.FightCore
{
    public class FightResult : IFightResult
    {
        public string WinnerName { get; }

        public int AliveMembersCount { get; }

        public FightResult(string winnerName, int aliveMembersCount)
        {
            WinnerName = winnerName;
            AliveMembersCount = aliveMembersCount;
        }
    }
}