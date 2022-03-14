using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Core
{
    public class GameField : IGameField
    {
        private IGameTile[,] _field;
        private ISpawnPointFactory _spawnPointsFactory;

        public GameField(int width, int height)
        {
            _field = new GameTile[width, height];
            _spawnPointsFactory = new SpawnPointsFactory();
        }

        public Vector2Int GetSize()
        {
            return new Vector2Int(_field.GetLength(0), _field.GetLength(1));
        }

        public IGameTile[] GetSpawnTiles(int side, int requiredCount)
        {
            return _spawnPointsFactory.Get(this, side, requiredCount);
        }

        public IGameTile GetTile(int x, int y)
        {
            return _field[x, y];
        }

        /// <summary>
        /// This method gets a view factory to initialize the field in one pass
        /// </summary>
        /// <param name="viewFactory"></param>
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

        public void Dispose()
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j].Occupied = false;
                }
            }
        }
    }
}