using MiniFight.Core.Actions;
using UnityEngine;

namespace MiniFight.Core.Fighters
{
    public class Boxer : Fighter
    {
        public override void Init(Color color)
        {
            base.Init(color);

            Moveable = new SimpleMove(Transform, _moveSpeed);
            Attacker = new SimpleAttack(Transform, _attackRadius, _attackPower);
        }
    }
}