using Entitas;
using Pathfinding.Examples;

namespace TowerDefence
{
    public class PlayerInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _context;
        private readonly IConfigurationService _configuration;

        public PlayerInitializeSystem(Contexts context, IConfigurationService configuration)
        {
            _context = context.game;
            _configuration = configuration;
        }
        public void Initialize()
        {
            GameEntity e = _context.CreateEntity();
            e.isPlayer = true;
            e.AddGold(_configuration.Game.AmountOfGold);
            e.AddHealth(_configuration.Game.PlayerHealth);
        }
    }
}