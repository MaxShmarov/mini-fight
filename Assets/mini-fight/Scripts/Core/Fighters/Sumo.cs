using MiniFight.Core.Actions;
using UnityEngine;

namespace MiniFight.Core.Fighters
{
    public class Sumo : Fighter
    {
        public override void Init(Color color)
        {
            base.Init(color);

            Moveable = new SimpleMove(Transform, _moveSpeed);
            Attacker = new SimpleAttack(Transform, _attackRadius + 0.5f, _attackPower);
        }
    }
}