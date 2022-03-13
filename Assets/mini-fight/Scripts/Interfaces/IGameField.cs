using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IGameField
    {
        void Initialize(IGameTileViewFactory viewFactory);

        IGameTile GetTile(int x, int y);
        Vector2Int GetSize();
    }
}