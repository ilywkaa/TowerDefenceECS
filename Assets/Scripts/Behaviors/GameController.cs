using System;
using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class GameController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] GameConfiguration _game;
        [SerializeField] TowerSettings _tower;
        [SerializeField] Transform _spawner;
        [SerializeField] EnemySettings[] _enemies;

        private Contexts _contexts;
        private Systems _systems;
        private IConfigurationService _configurationService;
        private IViewService _viewService;
        private IInputService _inputService;
        private IEnhanceService _enhanceService;
        private IPathfindingService _pathfindingService;

        private void OnEnable()
        {
            ConfigureServices();

            _contexts = Contexts.sharedInstance;
            _systems = new Systems()
                .Add(new TowerInitializeSystem(_contexts, _configurationService))
                .Add(new PlayerInitializeSystem(_contexts, _configurationService))

                //Executive
                .Add(new EnemySpawnSystem(_contexts, _configurationService, _pathfindingService))

                //Reactive
                .Add(new EnemyViewSystem(_contexts, _viewService, typeof(UnityView), _configurationService))
                .Add(new EnemyAgentSystem(_contexts, typeof(AStarAgent)))
                .Add(new AgentNavigationSystem(_contexts))
                .Add(new UserInputSystem(_contexts, _inputService, _enhanceService))
                .Add(new TowerEnhanceSystem(_contexts))
                //TODO: purchase income system realization
                ;

            //Cleaning up
            //.Add(new EntityDestroySystem(_contexts));

            _systems.Initialize();
        }
        private void ConfigureServices()
        {
            _configurationService = new ConfigurationService()
            {
                Game = _game,
                Enemies = _enemies,
                Tower = _tower,
                Spawner = _spawner
            };
            _viewService = new UnityViewService(_contexts, _configurationService);
            _inputService = new DefaultInputService();
            _enhanceService = new EnhanceService();
            _pathfindingService = new AStarPathfindingService(_configurationService);
        }
        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
	}
}