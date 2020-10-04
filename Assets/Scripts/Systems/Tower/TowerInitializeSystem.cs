using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class TowerInitializeSystem: IInitializeSystem
    {
        private Contexts _contexts;
        private IConfigurationService _configurationService;

        public TowerInitializeSystem(Contexts contexts, IConfigurationService configurationService)
        {
            _contexts = contexts;
            _configurationService = configurationService;
        }

        public void Initialize()
        {
            var viewObjects = GameObject.FindGameObjectsWithTag(_configurationService.Tower.Prefab.tag);
            foreach (var viewObject in viewObjects)
            {
                GameEntity e = _contexts.game.CreateEntity();
                e.isTower = true;
                e.AddDamage(_configurationService.Tower.Damage);
                e.AddFireRate(_configurationService.Tower.FireRate);
                viewObject.GetComponent<IView>().InitializeView(_contexts, e);
            }
        }
    }
}