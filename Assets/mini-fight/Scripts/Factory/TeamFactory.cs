using MiniFight.Core;
using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Factory
{
    [CreateAssetMenu(fileName = "Team factory", menuName = "Factories/New team factory")]
    public class TeamFactory : ScriptableObject, ITeamFactory
    {
        [SerializeField, Range(1, 5)] private int _maxMembersCount;
        [SerializeField] FighterFactory _factory;

        public ITeam Create(string name)
        {
            var parent = new GameObject(name);
            var team = new Team(name, _maxMembersCount);

            for (int i = 0; i < team.Members.Length; i++)
            {
                team.Members[i] = _factory.Create();
                team.Members[i].Transform.SetParent(parent.transform);
            }

            return team;
        }
    }
}