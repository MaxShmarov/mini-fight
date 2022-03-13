using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Core
{
    public class GameField : IGameField
    {
        private IGameTile[,] _field;

        public GameField(int width, int height)
        {
            _field = new GameTile[width, height];
        }

        public Vector2Int GetSize()
        {
            return new Vector2Int(_field.GetLength(0), _field.GetLength(1));
        }

        public IGameTile GetTile(int x, int y)
        {
            return _field[x, y];
        }

        public void Initialize(IGameTileViewFactory viewFactory)
        {
            var gameObject = new GameObject("Game field");

            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    var newTile = new GameTile(i, j);
                    var newTileView = viewFactory.Create(gameObject.transform);

                    newTile.Initialize(newTileView);

                    _field[i, j] = newTile;
                }
            }
        }
    }
}