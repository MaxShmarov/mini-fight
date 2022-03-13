using MiniFight.Factory;
using UnityEngine;

namespace MiniFight
{
    public class FightSceneStarter : MonoBehaviour
    {
        [SerializeField] private GameFieldFactory _factory;
        [SerializeField] private CameraController _camera;

        private void Start()
        {
            var field = _factory.Create();

            _camera.SetStartingPosition(field);
        }
    }
}