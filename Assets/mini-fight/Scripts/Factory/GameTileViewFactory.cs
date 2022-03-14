using MiniFight.Interfaces;
using MiniFight.View;
using UnityEngine;

namespace MiniFight.Factory
{
    [CreateAssetMenu(fileName = "Tile factory", menuName = "Factories/New tile factory")]
    public class GameTileViewFactory : ScriptableObject, IGameTileViewFactory
    {
        [SerializeField] private GameTileView[] _prefabs;

        public IGameTileView Create(Transform parentTransform)
        {
            return Instantiate(_prefabs.GetRandomElement(), parentTransform);
        }
    }
}