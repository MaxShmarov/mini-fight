using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore.Strategies
{
    public class StrategySelector : IStrategySelector
    {
        public IStrategy Select(ITeam team)
        {
            if (Random.value > 0.5f)
            {
                team.Strategy = new PersonalGoalStrategy();
            }
            else
            {
                team.Strategy = new CommonGoalStragegy();
            }

            return team.Strategy;
        }
    }
}