using MiniFight.Interfaces;
using UnityEngine;

public static class CommonExtension
{
    public static Vector2Int[] ToPositions(this IGameTile[] tiles)
    {
        var positions = new Vector2Int[tiles.Length];

        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = tiles[i].Position;
        }

        return positions;
    }
}