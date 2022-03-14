using System;
using UnityEngine;

namespace MiniFight.Interfaces
{
    public interface IFighter
    {
        public Guid Id { get; set; }
        public Transform Transform { get; }
        public IMoveable Moveable { get; }
        public IAttacker Attacker { get; }

        public void Init();
        public void ChangeMoveable(IMoveable moveable);
        public void ChangeAttacker(IAttacker attacker);
    }
}