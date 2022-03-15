using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IMoveable
    {
        Transform Transform { get; }
        float MoveSpeed { get; }
        ITarget Target { get; set; }

        void Move();
    }
}