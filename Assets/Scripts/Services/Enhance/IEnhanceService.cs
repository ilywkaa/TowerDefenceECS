namespace TowerDefence
{
    public interface IEnhanceService
    {
        FireRateComponent EnhanceTower(FireRateComponent tower);
        int GetTowerEnhanceCost(FireRateComponent tower);
        bool CanEnhance(GameEntity tower);
    }
}