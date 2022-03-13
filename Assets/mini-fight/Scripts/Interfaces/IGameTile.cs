using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IGameTile 
    {
        Vector2Int Position { get; }
        IGameTileView View { get; }

        void Initialize(IGameTileView view);
    }
}