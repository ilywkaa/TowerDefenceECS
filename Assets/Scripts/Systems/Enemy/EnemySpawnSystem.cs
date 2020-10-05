using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly IConfigurationService _configurationService;
        private readonly float _spawnTime;
        private readonly int _intervalEnemiesNumber;
        private float _timer;
        private int _spawnCounter;
        private readonly IPathfindingService _pathfindingService;
        public EnemySpawnSystem(Contexts contexts, IConfigurationService configuration,
            IPathfindingService pathfindingService)
        {
            _context = contexts.game;
            _spawnTime = configuration.Game.EnemySpawnTime;
            _intervalEnemiesNumber = configuration.Game.IntervalEnemiesSpawnNumber;
            _configurationService = configuration;
            _pathfindingService = pathfindingService;
        }
        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _spawnTime;
                _spawnCounter++;

                //TODO Check if not empty 
                EnemySettings[] enemies = _configurationService.Enemies;
                var enemy = enemies?[0];
                if(enemy == null)
                    return;
                
                int spawnEnemiesNumber = Random.Range(_spawnCounter, _spawnCounter + _intervalEnemiesNumber);
                for (int i = 0; i < spawnEnemiesNumber; i++)
                {
                    GameEntity e = _context.CreateEntity();
                    e.isEnemy = true;
                    e.AddDamage(enemy.Damage);
                    e.AddGold(enemy.Cost);
                    e.AddHealth(enemy.Health);
                    e.AddDestination(_pathfindingService.Target());
                    e.AddPosition(Vector3.positiveInfinity);
                }
            }

        }

        private Vector3 RandomPosition()
        {
            var maxNumberOfEnemies = _spawnCounter + _intervalEnemiesNumber;
            float x = Random.Range(- maxNumberOfEnemies * 2, maxNumberOfEnemies * 2);
            float z = Random.Range(- maxNumberOfEnemies * 2, maxNumberOfEnemies * 2);
            return new Vector3(x, 0, z);
        }
    }
}