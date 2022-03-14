using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface ITeam
    {
        string Name { get; }
        IFighter[] Members { get; }
        IStrategy Strategy { get; set; }

        void Spawn(Vector2Int[] spawnPositions, Vector3 rotation);
        void Update();
    }
}