using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore.Strategies
{
    public class StrategySelector : IStrategySelector
    {
        public void Select(ITeam team)
        {
            var randomValue = Random.Range(0, 1);

            if (randomValue > 0.5f)
            {
                team.Strategy = new PersonalGoalStrategy();
            }
            else
            {
                team.Strategy = new CommonGoalStragegy();
            }
        }
    }
}