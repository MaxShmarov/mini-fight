using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IGameField
    {
        void Initialize(IGameTileViewFactory viewFactory);
        void Reset();

        IGameTile GetTile(int x, int y);
        IGameTile[] GetSpawnTiles(int side, int requiredCount);
        Vector2Int GetSize();
    }
}