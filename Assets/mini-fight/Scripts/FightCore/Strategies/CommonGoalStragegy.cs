using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.FightCore.Strategies
{
    public class CommonGoalStragegy : BaseStrategy
    {
        private ITarget _target;

        public override void SetEnemy(ITeam enemy)
        {
            _target = null;

            base.SetEnemy(enemy);
        }

        public override void Update(ITeam team)
        {
            if (_target == null || !_target.IsAvailable)
                _target = TryToSelectClosestTarget(team.Members);

            for (int i = 0; i < team.Members.Length; i++)
            {
                if (!team.Members[i].IsAlive) { continue; }

                team.Members[i].SetTarget(_target);

                MakeAction(team.Members[i]);
            }
        }

        private ITarget TryToSelectClosestTarget(IFighter[] fighters)
        {
            ITarget target = null;
            float minDistance = float.MaxValue;

            for(int i = 0; i < fighters.Length; i++)
            {
                if (!fighters[i].IsAlive) { continue; }

                for(int j = 0; j < Enemy.Members.Length; j++)
                {
                    if (!Enemy.Members[j].IsAlive) { continue; }

                    var distance = Vector3.Distance(fighters[i].Transform.position, Enemy.Members[j].Transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;

                        target = Enemy.Members[j] as ITarget;
                    }
                }
            }

            return target;
        }
    }
}