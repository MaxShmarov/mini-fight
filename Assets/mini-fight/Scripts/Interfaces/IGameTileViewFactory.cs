using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IGameTileViewFactory
    {
        IGameTileView Create(Transform parentTransform);
    }
}