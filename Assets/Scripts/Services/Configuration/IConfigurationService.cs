using UnityEngine;

namespace TowerDefence
{
    public interface IConfigurationService
    {
        GameConfiguration Game { get; }
        EnemySettings[] Enemies{ get; }
        TowerSettings Tower { get; }
        Transform Spawner { get; }
    }
}