using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyAgentSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly Type _agentType;
        public EnemyAgentSystem(Contexts contexts, Type agentType) : base(contexts.game)
        {
            _contexts = contexts;
            _agentType = agentType;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.View));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gameObject = entity.view.Value.Transform.gameObject;
                IAgent agent = (IAgent) gameObject.AddComponent(_agentType);
                entity.AddAgent(agent);
            }
        }
    }
}