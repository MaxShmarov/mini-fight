using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore
{
    public class FightSystem : MonoBehaviour
    {
        private IFight _fight;
        private bool _isActive;

        public void Initialize(IGameField field, ITeam[] teams)
        {
            MoveFightersToStartingPositions(field, teams);

            _fight = new Fight(teams);
            _fight.Prepare();

            _fight.Ended += OnFightEnded;

            _isActive = true;
        }

        private void OnFightEnded(IFightResult result)
        {
            _fight.Ended -= OnFightEnded;

            _isActive = false;

            Debug.Log($"{result.WinnerName} victory. Alive: {result.AliveMembersCount}");
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