namespace MiniFight.Interfaces
{
    public interface IFightResult 
    {
        string WinnerName { get; }
        int AliveMembersCount { get; }
    }
}