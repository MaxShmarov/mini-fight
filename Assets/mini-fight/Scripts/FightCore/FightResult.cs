using MiniFight.Interfaces;
using System;

namespace MiniFight.FightCore
{
    public struct FightResult : IFightResult
    {
        public string WinnerName { get; }

        public int AliveMembersCount { get; }

        public TimeSpan Time { get; }

        public FightResult(string winnerName, int aliveMembersCount, float timeInSeconds)
        {
            WinnerName = winnerName;
            AliveMembersCount = aliveMembersCount;
            Time = TimeSpan.FromSeconds(timeInSeconds);
        }
    }
}