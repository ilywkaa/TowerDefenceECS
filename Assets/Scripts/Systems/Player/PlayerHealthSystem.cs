using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class PlayerHealthSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly GameContext _context;
        private GameEntity _player;
        public void Initialize()
        {
            _player = _context.GetGroup(GameMatcher.Player).GetSingleEntity();
        }
        public PlayerHealthSystem(Contexts context) : base(context.game)
        {
            _context = context.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Hit));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy && entity.hasHit;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var hitDamage = entity.hit.value;
                Debug.Log($"Player health is {_player.health.value}.");
                if (_player.health.value - hitDamage > 0)
                {
                    _player.ReplaceHealth(_player.health.value - hitDamage);
                }
                else
                {
                    _player.ReplaceHealth(0);
                    _player.isGameOver = true; //TODO: reactive UI system
                }
                entity.RemoveHit();
            }
        }
    }
}