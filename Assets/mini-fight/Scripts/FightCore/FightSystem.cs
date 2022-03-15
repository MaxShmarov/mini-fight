using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.FightCore
{
    public class FightSystem : MonoBehaviour
    {
        private IFight _fight;
        private Action<IFightResult> _onFinishCallback;
        private bool _isActive;

        public void Initialize(IGameField field, ITeam[] teams, Action<IFightResult> onFinishCallback)
        {
            _onFinishCallback = onFinishCallback;

            MoveFightersToStartingPositions(field, teams);

            _fight = new Fight();
            _fight.Ended += OnFightEnded;
            _fight.Prepare(teams);

            StartFight();
        }

        public void StartFight()
        {
            _fight?.Start();

            _isActive = true;
        }

        public void ResetSystem()
        {
            _fight.Reset();
            _onFinishCallback = null;
            _isActive = false;
        }

        private void OnFightEnded(IFightResult result)
        {
            _fight.Ended -= OnFightEnded;

            _isActive = false;

            _onFinishCallback?.Invoke(result);
        }

        private void Update()
        {
            if (!_isActive) { return; }

            _fight?.Update();
        }

        private void MoveFightersToStartingPositions(IGameField field, ITeam[] teams)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                var spawnTiles = field.GetSpawnTiles(i, teams[i].Members.Length);

                teams[i].Spawn(spawnTiles.ToPositions(), DefineStartingRotation(i));
            }
        }

        private Vector3 DefineStartingRotation(int teamIndex)
        {
            return teamIndex % 2 == 0 ? Vector3.zero : new Vector3(0, 180, 0);
        }
    }
}