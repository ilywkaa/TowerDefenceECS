using System;
using UnityEngine;

namespace TowerDefence
{
    public class EnhanceService : IEnhanceService
    {
        //TODO take out 'scaleFactors' (make DI) and receive it here through ctor
        public FireRateComponent EnhanceTower(FireRateComponent tower)
        {
            float scaleFactor = 3f / 2f;
            var fireRate = Mathf.CeilToInt(tower.value * scaleFactor);
            fireRate = fireRate > 10 ? 10 : fireRate;
            return new FireRateComponent() { value = fireRate };
        }

        public int GetTowerEnhanceCost(FireRateComponent tower)
        {
            float scaleFactor = 30f / 4f;
            return Mathf.CeilToInt(tower.value * scaleFactor);
        }

        public bool CanEnhance(GameEntity tower)
        {
            if (!tower.isTower && !tower.hasFireRate)
                throw new ArgumentException($"GameEntity index = {tower.creationIndex} is not valid argument.");

            var oldFireRate = tower.fireRate;
            return oldFireRate != EnhanceTower(tower.fireRate);
        }
    }
}