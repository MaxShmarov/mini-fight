using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IMoveable
    {
        public float MoveSpeed { get; }
        void MoveTo(Transform transform, Vector2Int position);
    }
}