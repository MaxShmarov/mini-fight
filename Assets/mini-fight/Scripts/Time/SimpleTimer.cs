using MiniFight.Interfaces;

namespace MiniFight.Time
{
    public class SimpleTimer : ITimer
    {
        public float TimeInSeconds { get; private set; }

        public bool IsStopped { get; private set; }

        public void Tick()
        {
            if (IsStopped) { return; }

            TimeInSeconds += UnityEngine.Time.deltaTime;
        }

        public void Start()
        {
            TimeInSeconds = 0;
            IsStopped = false;
        }

        public void Stop()
        {
            IsStopped = true;
        }
    }
}