namespace MiniFight.Interfaces
{
    public interface IStrategy
    {
        ITeam Enemy { get; }
        void SetEnemy(ITeam enemy);

        void Update(ITeam team);
    }
}