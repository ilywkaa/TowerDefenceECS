using UnityEngine;

namespace TowerDefence
{
    public class ConfigurationService : IConfigurationService
    {
        public GameConfiguration Game { get; set; }
        public EnemySettings[] Enemies { get; set; }
        public TowerSettings Tower { get; set; }
        public Transform Spawner { get; set; }
    }
}