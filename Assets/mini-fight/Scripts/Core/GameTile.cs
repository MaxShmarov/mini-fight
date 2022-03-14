using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Core
{
    public class GameTile : IGameTile
    {
        private Vector2Int _position;

        public Vector2Int Position => _position;

        public IGameTileView View { get; private set; }
        public bool Occupied { get; set; }

        public GameTile(int x, int y)
        {
            _position = new Vector2Int(x, y);
        }

        public void Initialize(IGameTileView view)
        {
            view.Initialize(Position);

            View = view;
        }
    }
}