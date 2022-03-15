using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore.Strategies
{
    public class PersonalGoalStrategy : BaseStrategy
    {
        public override void Update(ITeam team)
        {
            for (int i = 0; i < team.Members.Length; i++)
            {
                var member = team.Members[i];

                if (!member.IsAlive) { continue; }

                if (!HasTarget(member))
                    member.SetTarget(TryToSelectClosestTarget(member));

                MakeAction(member);
            }
        }

        private bool HasTarget(IFighter fighter)
        {
            return (fighter.Moveable.Target != null && fighter.Moveable.Target.IsAvailable) &&
                (fighter.Attacker.Target != null && fighter.Attacker.Target.IsAvailable);
        }

        private ITarget TryToSelectClosestTarget(IFighter fighter)
        {
            ITarget target = null;
            float minDistance = float.MaxValue;

            for (int j = 0; j < Enemy.Members.Length; j++)
            {
                if (!Enemy.Members[j].IsAlive) { continue; }

                var distance = Vector3.Distance(fighter.Transform.position, Enemy.Members[j].Transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;

                    target = Enemy.Members[j] as ITarget;
                }
            }

            return target;
        }
    }
}