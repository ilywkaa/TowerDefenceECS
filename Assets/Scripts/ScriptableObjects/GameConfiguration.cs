using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "ScriptableObjects/GameConfiguration", order = 1)]
    public class GameConfiguration : ScriptableObject
    {
        [Header("Player")] 

        [Min(0f)] 
        [SerializeField] 
        private int _startAmountOfGold;
        [Min(1f)]
        [SerializeField]
        private int _startPlayerHealth; // N
        [Space]

        [Header("Gameplay")]

        [Min(1f)]
        [SerializeField]
        private float _enemySpawnDeltaTime;
        [Min(0f)]
        [SerializeField]
        private int _intervalOfRandomNumberEnemiesSpawn; //number of enemies on spawn is random 

        [SerializeField] private GameObject _targetPrefab;

        public float EnemySpawnTime => _enemySpawnDeltaTime;
        public int IntervalEnemiesSpawnNumber => _intervalOfRandomNumberEnemiesSpawn;
        public int AmountOfGold => _startAmountOfGold;
        public int PlayerHealth => _startPlayerHealth;
        public GameObject TargetPrefab => _targetPrefab;
    }
}