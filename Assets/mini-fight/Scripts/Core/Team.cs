using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Core
{
    public class Team : ITeam
    {
        public event Action<ITeam, int> AliveMembersCountChanged;
        public string Name { get; }
        public Color Color { get; }
        public int AliveMembersCount { get; private set; }
        public IFighter[] Members { get; private set; }
        public IStrategy Strategy { get; set; }

        public Team(string name, int membersCount, Color color)
        {
            Name = name;
            Color = color;
            Members = new IFighter[membersCount];
        }

        public void Spawn(Vector2Int[] spawnPositions, Vector3 rotation)
        {
            for(int i = 0; i < Members.Length; i++)
            {
                if (i < spawnPositions.Length)
                {
                    Members[i].Init(Color);
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

        public void Reset()
        {
            for (int i = 0; i < Members.Length; i++)
            {
                Members[i].Died -= OnMemberDied;
                Members[i].DestroyThis();
            }

            Members = null;
            Strategy = null;
            AliveMembersCount = 0;
        }
    }
}