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
        [SerializeField] private FightSystem _fightSystem;
        [SerializeField] private CameraController _camera;

        private void Start()
        {
            var field = _factory.Create();

            var teamRadiant = _teamFactory.Create("Radiant");
            var teamDire = _teamFactory.Create("Dire");

            _fightSystem.Initialize(field, new ITeam[] { teamRadiant, teamDire });

            _camera.SetStartingPosition(field);
        }
    }
}