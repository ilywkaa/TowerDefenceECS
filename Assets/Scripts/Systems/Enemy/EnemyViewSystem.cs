using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyViewSystem: ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly IViewService _viewService;
        private readonly IConfigurationService _configuration;
        private readonly Type _viewType;
        public EnemyViewSystem(Contexts contexts, IViewService viewService, Type viewType, IConfigurationService configuration) : base(contexts.game) 
        {
            _contexts = contexts;
            _viewService = viewService;
            _configuration = configuration;
            _viewType = viewType;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher
                .AllOf(GameMatcher.Enemy, GameMatcher.Damage)
                .NoneOf(GameMatcher.Player, GameMatcher.Tower
                ));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                GameObject viewObject = _viewService.LoadAsset(_configuration.Enemies[0]?.Prefab.name);
                
                var view = (IView) viewObject.AddComponent(_viewType);
                if (view != null)
                {
                    view.InitializeView(_contexts, entity);
                    entity.AddView(view);
                }

            }
        }
    }
}