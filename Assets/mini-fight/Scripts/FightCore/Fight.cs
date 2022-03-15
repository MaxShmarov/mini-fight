using MiniFight.FightCore.Strategies;
using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore
{
    public class Fight : IFight
    {
        private IGameField _field;
        private ITeam[] _teams;
        private IStrategySelector _strategySelector;

        public Fight(IGameField field, ITeam[] teams)
        {
            _field = field;
            _teams = teams;

            _strategySelector = new StrategySelector();
        }

        public void Prepare()
        {
            MoveFightersToStartingPositions();
            SelectStrategiesToEachTeam();
        }

        public void Update()
        {
            for(int i = 0; i < _teams.Length; i++)
            {
                _teams[i].Update();
            }
        }

        public void End()
        {
            throw new System.NotImplementedException();
        }

        private void SelectStrategiesToEachTeam()
        {
            for(int i = 0; i < _teams.Length; i++)
            {
                var strategy = _strategySelector.Select(_teams[i]);

                if (_teams.Length == 1) { continue; }

                var enemyIndex = i + 1 == _teams.Length ? 0 : i + 1;

                strategy.SetEnemy(_teams[enemyIndex]);
            }
        }

        private void MoveFightersToStartingPositions()
        {
            for(int i = 0; i < _teams.Length; i++)
            {
                var spawnTiles = _field.GetSpawnTiles(i, _teams[i].Members.Length);

                _teams[i].Spawn(spawnTiles.ToPositions(), i % 2 == 0 ? Vector3.zero : new Vector3(0, 180, 0));
            }
        }
    }
}