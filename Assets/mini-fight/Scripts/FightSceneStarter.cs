using MiniFight.Factory;
using MiniFight.FightCore;
using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight
{
    public class FightSceneStarter : MonoBehaviour
    {
        [SerializeField] private GameFieldFactory _factory;
        [SerializeField] private TeamFactory _teamFactory;
        [SerializeField] private FightLoop fightLoop;
        [SerializeField] private CameraController _camera;

        private void Start()
        {
            var field = _factory.Create();

            var teamRadiant = _teamFactory.Create("Radiant");
            var teamDire = _teamFactory.Create("Dire");

            var fight = new Fight(field, new ITeam[] { teamRadiant, teamDire });
            fight.Prepare();

            fightLoop.Initialize(fight);

            _camera.SetStartingPosition(field);
        }
    }
}