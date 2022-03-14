using MiniFight.Interfaces;
using System;
using UnityEngine;

namespace MiniFight.Core.Fighters
{
    public abstract class Fighter : MonoBehaviour, IFighter
    {
        [SerializeField, Range(0, 2)] protected float _moveSpeed;
        [SerializeField, Range(0, 2)] protected float _attackRadius;
        [SerializeField, Range(0, 2)] protected float _attackPower;

        public Guid Id { get; set; }
        public IMoveable Moveable { get; private set; }
        public IAttacker Attacker { get; private set; }
        public Transform Transform => transform;

        public abstract void Init();

        public virtual void ChangeAttacker(IAttacker attacker)
        {
            Attacker = attacker;
        }

        public virtual void ChangeMoveable(IMoveable moveable)
        {
            Moveable = moveable;
        }
    }
}