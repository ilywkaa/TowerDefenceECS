using System.Collections.Generic;
using Entitas;

namespace TowerDefence
{
    public class PlayerPurchaseSystem : ReactiveSystem<GameEntity>
    {
        public PlayerPurchaseSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}