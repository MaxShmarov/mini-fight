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

        private GameObject _parent;

        public ITeam Create(string name)
        {
            if (_parent == null)
                _parent = new GameObject("Members");

            var team = new Team(name, _maxMembersCount, Random.ColorHSV());

            for (int i = 0; i < team.Members.Length; i++)
            {
                team.Members[i] = _factory.Create();
                team.Members[i].Transform.SetParent(_parent.transform);
            }

            return team;
        }
    }
}