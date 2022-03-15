using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Core.Fighters
{
    public abstract class Fighter : MonoBehaviour, IFighter, ITarget, IDamageable
    {
        public event Action<IFighter> Died;
        public Guid Id { get; set; }
        public float Health { get; protected set; }
        public IMoveable Moveable { get; protected set; }
        public IAttacker Attacker { get; protected set; }
        public Transform Transform => transform;
        public bool IsAlive => Health > 0;
        public bool IsAvailable => IsAlive;

        [SerializeField, Range(0, 2)] protected float _moveSpeed;
        [SerializeField, Range(0, 2)] protected float _attackRadius;
        [SerializeField, Range(0, 2)] protected float _attackPower;
        [SerializeField, Range(10, 50)] protected float _maxHealth;
        [SerializeField] protected GameObject _view;

        public virtual void Init()
        {
            Health = _maxHealth;
        }

        public virtual void ChangeAttacker(IAttacker attacker)
        {
            Attacker = attacker;
        }

        public virtual void ChangeMoveable(IMoveable moveable)
        {
            Moveable = moveable;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Died?.Invoke(this);

                Destroy(_view);
            }
        }

        public void SetTarget(ITarget target)
        {
            Attacker.Target = target;
            Moveable.Target = target;
        }

        public void DestroyThis()
        {
            Destroy(gameObject);
        }
    }
}