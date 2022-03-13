using MiniFight.Interfaces;
using MiniFight.View;
using UnityEngine;

namespace MiniFight.Factory
{
    [CreateAssetMenu(fileName = "Tile factory", menuName = "Configs/New tile factory")]
    public class GameTileViewFactory : ScriptableObject, IGameTileViewFactory
    {
        [SerializeField] private GameTileView[] _prefabs;

        public IGameTileView Create(Transform parentTransform)
        {
            var index = Random.Range(0, _prefabs.Length);

            return Instantiate(_prefabs[index], parentTransform);
        }
    }
}