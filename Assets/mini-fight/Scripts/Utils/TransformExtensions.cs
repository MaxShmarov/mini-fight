using UnityEngine;

public static class TransformExtensions
{
    public static void SetPosition(this Transform transform, Vector2Int vector2Int)
    {
        transform.position = new Vector3(vector2Int.x, 0, vector2Int.y);
    }
}