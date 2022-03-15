using MiniFight.Core.Actions;

namespace MiniFight.Core.Fighters
{
    public class Dodger : Fighter
    {
        public override void Init()
        {
            base.Init();

            Moveable = new SimpleMove(Transform, _moveSpeed);
            Attacker = new SimpleAttack(Transform, _attackRadius, _attackPower);
        }
    }
}