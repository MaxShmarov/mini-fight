using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IAttacker
    {
        Transform Transform { get; }
        ITarget Target { get; set; }
        float AttackRadius { get; }
        float AttackPower { get; }
        bool CanAttack();
        void Attack();
    }
}