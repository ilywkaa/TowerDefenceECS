using System.Collections.Generic;
using Entitas;

namespace TowerDefence
{
    public class AgentNavigationSystem : ReactiveSystem<GameEntity>
    {
        public AgentNavigationSystem(Contexts contexts) : base(contexts.game) { }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Agent)); //ENEMY
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy && entity.hasAgent;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var destination = entity.destination.Target;
                entity.agent.value.SetDestination(destination);
                entity.RemoveDestination();
            }
        }
    }
}