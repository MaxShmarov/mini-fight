using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Core
{
    public class Team : ITeam
    {
        public event Action<ITeam, int> AliveMembersCountChanged;
        public string Name { get; }
        public int AliveMembersCount { get; private set; }
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
                    Members[i].Init();
                    Members[i].Transform.SetPosition(spawnPositions[i]);
                    Members[i].Transform.rotation = Quaternion.Euler(rotation);
                    Members[i].Died += OnMemberDied;

                    AliveMembersCount++;
                }
            }
        }

        private void OnMemberDied(IFighter fighter)
        {
            fighter.Died -= OnMemberDied;

            AliveMembersCount--;

            AliveMembersCountChanged?.Invoke(this, AliveMembersCount);
        }

        public void Update()
        {
            if (Strategy == null)
                Debug.LogWarning("No strategy selected");

            Strategy?.Update(this);
        }

        public void Dispose()
        {
            for (int i = 0; i < Members.Length; i++)
            {
                Members[i].Died -= OnMemberDied;
            }

            AliveMembersCount = 0;
        }
    }
}