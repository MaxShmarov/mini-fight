using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore
{
    public class FightLoop : MonoBehaviour
    {
        private IFight _fight;

        public void Initialize(IFight fight)
        {
            _fight = fight;
        }

        private void Update()
        {
            if (_fight != null)
                _fight.Update();
        }
    }
}