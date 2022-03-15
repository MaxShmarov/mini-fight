namespace MiniFight.Interfaces
{
    public interface ITimer
    {
        public float TimeInSeconds { get; }
        public bool IsStopped { get; }
        void Start();
        void Stop();
        void Tick();
    }
}