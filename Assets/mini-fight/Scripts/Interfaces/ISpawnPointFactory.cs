namespace MiniFight.Interfaces
{
    public interface ISpawnPointFactory
    {
        IGameTile[] Get(IGameField field, int side, int requiredCount);
    }
}