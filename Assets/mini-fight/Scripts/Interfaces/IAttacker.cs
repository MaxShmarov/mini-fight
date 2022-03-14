namespace MiniFight.Interfaces
{
    public interface IAttacker
    {
        float AttackRadius { get; }
        float AttackPower { get; }
        void Attack();
    }
}