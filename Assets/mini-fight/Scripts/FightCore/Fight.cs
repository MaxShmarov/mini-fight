using MiniFight.FightCore.Strategies;
using MiniFight.Interfaces;
using System;

namespace MiniFight.FightCore
{
    public class Fight : IFight
    {
        public event Action<IFightResult> Ended;

        private ITeam[] _teams;
        private IStrategySelector _strategySelector;

        public Fight(ITeam[] teams)
        {
            _teams = teams;

            _strategySelector = new StrategySelector();
        }

        public void Prepare()
        {
            if (_teams.Length <= 1) { return; }

            for(int i = 0; i < _teams.Length; i++)
            {
                _teams[i].AliveMembersCountChanged += OnAliveMembersCountChanged;

                var strategy = _strategySelector.Select(_teams[i]);

                var enemyIndex = i + 1 == _teams.Length ? 0 : i + 1;

                strategy.SetEnemy(_teams[enemyIndex]);
            }
        }

        private void OnAliveMembersCountChanged(ITeam team, int aliveMembersCount)
        {
            if (aliveMembersCount == 0)
            {
                var winner = team.Strategy.Enemy;

                Ended?.Invoke(new FightResult(winner.Name, winner.AliveMembersCount));
            }
        }

        public void Update()
        {
            for(int i = 0; i < _teams.Length; i++)
            {
                _teams[i].Update();
            }
        }

        public void Dispose()
        {
            for(int i = 0; i < _teams.Length; i++)
            {
                _teams[i].AliveMembersCountChanged -= OnAliveMembersCountChanged;
            }
        }
    }
}