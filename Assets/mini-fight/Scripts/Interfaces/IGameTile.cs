using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IGameTile 
    {
        Vector2Int Position { get; }
        IGameTileView View { get; }
        bool Occupied { get; set; }
        void Initialize(IGameTileView view);
    }
}