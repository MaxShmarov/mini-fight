using MiniFight.Core.Fighters;
using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Factory
{
    [CreateAssetMenu(fileName = "Fighter factory", menuName = "Factories/New fighter factory")]
    public class FighterFactory : ScriptableObject, IFighterFactory
    {
        [SerializeField] private Fighter[] _prefabs;

        public IFighter Create()
        {
            var fighter = Instantiate(_prefabs.GetRandomElement());

            fighter.Id = Guid.NewGuid();

            return fighter;
        }
    }
}