using System;
using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IFighter
    {
        event Action<IFighter> Died;

        public Guid Id { get; set; }
        public Transform Transform { get; }
        public IMoveable Moveable { get; }
        public IAttacker Attacker { get; }
        bool IsAlive { get; }

        public void Init();
        public void SetTarget(ITarget target);
        public void ChangeMoveable(IMoveable moveable);
        public void ChangeAttacker(IAttacker attacker);
        void DestroyThis();
    }
}