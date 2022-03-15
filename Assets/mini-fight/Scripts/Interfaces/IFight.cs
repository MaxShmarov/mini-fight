using System;

namespace MiniFight.Interfaces
{
    public interface IFight
    {
        event Action<IFightResult> Ended;

        bool IsActive { get; }
        void Prepare(ITeam[] teams);
        void Start();
        void Update();
        void Reset();
    }
}