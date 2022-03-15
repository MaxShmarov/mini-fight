using MiniFight.FightCore.Strategies;
using MiniFight.Interfaces;
using MiniFight.Time;
using System;

namespace MiniFight.FightCore
{
    public class Fight : IFight
    {
        public event Action<IFightResult> Ended;

        public bool IsActive { get; private set; }

        private ITeam[] _teams;
        private IStrategySelector _strategySelector;
        private ITimer _timer;

        public Fight()
        {
            _timer = new SimpleTimer();
            _strategySelector = new StrategySelector();
        }

        public void Prepare(ITeam[] teams)
        {
            _teams = teams;

            if (_teams.Length <= 1) { return; }

            for(int i = 0; i < _teams.Length; i++)
            {
                _teams[i].AliveMembersCountChanged += OnAliveMembersCountChanged;

                var strategy = _strategySelector.Select(_teams[i]);

                var enemyIndex = i + 1 == _teams.Length ? 0 : i + 1;

                strategy.SetEnemy(_teams[enemyIndex]);
            }
        }

        public void Start()
        {
            _timer.Start();

            IsActive = true;
        }

        public void Update()
        {
            if (!IsActive) { return; }

            _timer?.Tick();

            for (int i = 0; i < _teams.Length; i++)
            {
                _teams[i].Update();
            }
        }

        public void Reset()
        {
            for (int i = 0; i < _teams.Length; i++)
            {
                _teams[i].AliveMembersCountChanged -= OnAliveMembersCountChanged;
                _teams[i].Reset();
            }

            _teams = null;
        }

        private void OnAliveMembersCountChanged(ITeam team, int aliveMembersCount)
        {
            if (aliveMembersCount == 0)
            {
                IsActive = false;

                _timer.Stop();

                var winner = team.Strategy.Enemy;

                Ended?.Invoke(new FightResult(winner.Name, winner.AliveMembersCount, _timer.TimeInSeconds));
            }
        }
    }
}