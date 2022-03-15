using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Core.Actions
{
    public class SimpleAttack : IAttacker
    {
        public Transform Transform { get; }
        public ITarget Target { get; set; }
        public float AttackRadius { get; }
        public float AttackPower { get; }

        public SimpleAttack(Transform transform, float attackRadius, float attackPower)
        {
            Transform = transform;
            AttackRadius = attackRadius;
            AttackPower = attackPower;
        }

        public bool CanAttack()
        {
            if (Target == null || Transform == null) { return false; }

            var distance = Vector3.Distance(Transform.position, Target.Transform.position);

            return distance < AttackRadius;
        }

        public void Attack()
        {
            if (Target is IDamageable damageable)
            {
                damageable.TakeDamage(AttackPower);
            }
        }
    }
}