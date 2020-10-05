using System.Collections.Generic;
using Entitas;

namespace TowerDefence
{
    public class UIGoldSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly GameContext _context;
        private UIController _ui;
        public UIGoldSystem(Contexts contexts, UIController ui) : base(contexts.game)
        {
            _context = contexts.game;
            _ui = ui;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Gold);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _ui.Gold.text = entities.SingleEntity().gold.value.ToString();
        }

        public void Initialize()
        {
            var player = _context.GetGroup(GameMatcher.Player).GetSingleEntity();
            _ui.Gold.text = player.gold.value.ToString();
        }
    }
}