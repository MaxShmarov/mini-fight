using System;

namespace MiniFight.Interfaces
{
    public interface IFight : IDisposable
    {
        event Action<IFightResult> Ended;

        void Prepare();
        void Update();
    }
}