using System.Collections.Generic;
using Entitas;

namespace TowerDefence
{
    public class UIGameOverSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _context;
        private UIController _ui;
        public UIGameOverSystem(Contexts contexts, UIController ui) : base(contexts.game)
        {
            _context = contexts.game;
            _ui = ui;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameOver);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameOver;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _ui.GameOverObject.SetActive(true); //TODO: create a UI interface and hide this :)
        }
    }
}