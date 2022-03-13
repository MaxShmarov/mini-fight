using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.View
{
    public class GameTileView : MonoBehaviour, IGameTileView
    {
        public void Initialize(Vector2Int position)
        {
            gameObject.name = $"{position.x}:{position.y}";

            transform.SetPosition(position);
        }
    }
}