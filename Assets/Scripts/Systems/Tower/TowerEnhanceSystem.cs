using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Entitas;
using Debug = UnityEngine.Debug;

namespace TowerDefence
{
    public class TowerEnhanceSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _context;
        public TowerEnhanceSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TowerEnhance, GameMatcher.Tower));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTowerEnhance && entity.isTower;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ReplaceFireRate(entity.towerEnhance.fireRate.value);
                entity.RemoveTowerEnhance();
            }
        }
    }
}