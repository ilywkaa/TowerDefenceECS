using System.Collections.Generic;
using Entitas;

namespace TowerDefence
{
    public class UIHealthSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly GameContext _context;
        private UIController _ui;
        public UIHealthSystem(Contexts contexts, UIController ui) : base(contexts.game)
        {
            _context = contexts.game;
            _ui = ui;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Health);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _ui.Health.text = entities.SingleEntity().health.value.ToString();
        }

        public void Initialize()
        {
            var player = _context.GetGroup(GameMatcher.Player).GetSingleEntity();
            _ui.Health.text = player.health.value.ToString();
        }
    }
}