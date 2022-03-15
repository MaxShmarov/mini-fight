using MiniFight.Factory;
using MiniFight.FightCore;
using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Contexts
{
    public class FightSceneContext : BaseContext
    {
        public event Action<IFightResult> Finish;

        [SerializeField] private GameFieldFactory _fieldFactory;
        [SerializeField] private TeamFactory _teamFactory;
        [SerializeField] private FightSystem _fightSystem;

        private IGameField _field;

        public override void StartContext()
        {
            if (_field != null)
            {
                _field.Reset();
            }
            else
            {
                _field = _fieldFactory.Create();
            }

            var teamRadiant = _teamFactory.Create("Radiant");
            var teamDire = _teamFactory.Create("Dire");

            _fightSystem.Initialize(_field, new ITeam[] { teamRadiant, teamDire }, Finish);
        }

        public void Restart()
        {
            _fightSystem.ResetSystem();

            StartContext();
        }
    }
}