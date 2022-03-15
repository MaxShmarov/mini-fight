using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface ITarget
    {
        Transform Transform { get; }
        bool IsAvailable { get; }
    }
}