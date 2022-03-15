using MiniFight.Interfaces;

namespace MiniFight.FightCore.Strategies
{
    public abstract class BaseStrategy : IStrategy
    {
        public ITeam Enemy { get; protected set; }

        public virtual void SetEnemy(ITeam enemy)
        {
            Enemy = enemy;
        }

        public abstract void Update(ITeam team);

        protected void MakeAction(IFighter fighter)
        {
            if (fighter.Attacker.CanAttack())
            {
                fighter.Attacker.Attack();
            }
            else
            {
                fighter.Moveable.Move();
            }
        }
    }
}