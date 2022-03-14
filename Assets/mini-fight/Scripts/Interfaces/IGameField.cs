using System;
using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IGameField : IDisposable
    {
        void Initialize(IGameTileViewFactory viewFactory);

        IGameTile GetTile(int x, int y);
        IGameTile[] GetSpawnTiles(int side, int requiredCount);
        Vector2Int GetSize();
    }
}