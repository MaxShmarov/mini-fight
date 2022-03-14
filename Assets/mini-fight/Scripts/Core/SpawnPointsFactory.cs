using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Core
{
    public class SpawnPointsFactory : ISpawnPointFactory
    {
        public IGameTile[] Get(IGameField field, int side, int requiredCount)
        {
            if (CanCreateSpawnPoints(field, requiredCount))
            {
                var fromLeft = side % 2 == 0;

                return GetPointsBySide(field, fromLeft, requiredCount);
            }

            return new IGameTile[0];
        }

        private IGameTile[] GetPointsBySide(IGameField field, bool fromLeft, int requiredCount)
        {
            var result = new IGameTile[requiredCount];
            var fieldSize = field.GetSize();
            var xFrom = fromLeft ? 0 : fieldSize.x / 2;
            var xTo = fromLeft ? fieldSize.x / 2 : fieldSize.x;
            var availableByY = fieldSize.y;
            
            while (requiredCount > 0)
            {
                var xPosition = Random.Range(xFrom, xTo);
                var yPosition = Random.Range(0, availableByY);

                var tile = field.GetTile(xPosition, yPosition);

                if (!tile.Occupied)
                {
                    tile.Occupied = true;

                    result[requiredCount - 1] = tile;

                    requiredCount--;
                }
            }

            return result;
        }

        private bool CanCreateSpawnPoints(IGameField field, int requiredCount)
        {
            var fieldSize = field.GetSize();

            return (fieldSize.x / 2) * fieldSize.y >= requiredCount;
        }
    }
}