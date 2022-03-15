namespace MiniFight.Interfaces
{
    public interface IStrategySelector
    {
        IStrategy Select(ITeam team);
    }
}