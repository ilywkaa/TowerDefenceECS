using System.Collections.Generic;
using Entitas;

namespace TowerDefence
{
    public class PlayerPurchaseSystem : ReactiveSystem<GameEntity>
    {
        public PlayerPurchaseSystem(Contexts contexts) : base(contexts.game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Purchase));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.hasPurchase;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var goldAmount = entity.gold.value - entity.purchase.value;
                entity.ReplaceGold(goldAmount);
                entity.RemovePurchase();
            }
        }
    }
}