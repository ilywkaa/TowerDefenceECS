using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class UserInputSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IInputService _inputService;
        private readonly IEnhanceService _enhanceService;
        private GameEntity _player;

        public void Initialize()
        {
            _player = _contexts.game.GetGroup(GameMatcher.Player).GetSingleEntity();
        }
        public UserInputSystem(Contexts contexts, IInputService inputService, IEnhanceService enhanceService)
        {
            _contexts = contexts;
            _inputService = inputService;
            _enhanceService = enhanceService;
        }
        public void Execute()
        {
            if (_inputService.Click())
            {
                GameEntity entity = _inputService.GetClicked();
                if (entity != null && entity.isTower)
                {
                    var enhanceCost = _enhanceService.GetTowerEnhanceCost(entity.fireRate);
                    if (_player.hasGold 
                        && _player.gold.value > enhanceCost
                        && _enhanceService.CanEnhance(entity))
                    {
                        entity.ReplaceTowerEnhance(_enhanceService.EnhanceTower(entity.fireRate));
                        _player.AddPurchase(enhanceCost);
                        Debug.Log("The enhancement was succeed.");
                    }
                    else
                    {
                        Debug.Log("You need more gold.");
                    }
                }
            }
        }

    }
}