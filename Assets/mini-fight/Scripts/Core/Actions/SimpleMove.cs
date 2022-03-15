using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Core.Actions
{
    public class SimpleMove : IMoveable
    {
        public Transform Transform { get; }
        public float MoveSpeed { get; }
        public ITarget Target { get; set; }

        private const float SPEED_FACTOR = 0.01f;

        public SimpleMove(Transform transform, float moveSpeed)
        {
            Transform = transform;
            MoveSpeed = moveSpeed * SPEED_FACTOR;
        }

        public void Move()
        {
            if (Target == null || Transform == null) { return; }

            Transform.position = Vector3.MoveTowards(Transform.position, Target.Transform.position, MoveSpeed);
        }
    }
}