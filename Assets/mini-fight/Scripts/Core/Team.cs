using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Core
{
    public class Team : ITeam
    {
        public string Name { get; }
        public IFighter[] Members { get; }
        public IStrategy Strategy { get; set; }

        public Team(string name, int membersCount)
        {
            Name = name;
            Members = new IFighter[membersCount];
        }

        public void Spawn(Vector2Int[] spawnPositions, Vector3 rotation)
        {
            for(int i = 0; i < Members.Length; i++)
            {
                if (i < spawnPositions.Length)
                {
                    Members[i].Transform.SetPosition(spawnPositions[i]);
                    Members[i].Transform.rotation = Quaternion.Euler(rotation);
                }
            }
        }

        public void Update()
        {
            if (Strategy == null)
                Debug.LogWarning("No strategy selected");

            Strategy?.Update(this);
        }
    }
}