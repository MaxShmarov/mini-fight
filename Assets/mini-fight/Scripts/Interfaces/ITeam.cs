using System;
using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface ITeam
    {
        event Action<ITeam, int> AliveMembersCountChanged;

        string Name { get; }
        int AliveMembersCount { get; }
        IFighter[] Members { get; }
        IStrategy Strategy { get; set; }

        void Spawn(Vector2Int[] spawnPositions, Vector3 rotation);
        void Update();
        void Reset();
    }
}