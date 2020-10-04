using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "NewEnemySettings", menuName = "ScriptableObjects/EnemySettings", order = 2)]
    public class EnemySettings : ScriptableObject
    {
        [Min(0f)] 
        [SerializeField] 
        private int _cost;
        [Min(0f)]
        [SerializeField]
        private int _damage; 
        [SerializeField]
        private int _health;
        [SerializeField]
        private GameObject _prefab;
        
        public int Cost => _cost;
        public int Damage => _damage;
        public int Health => _health;
        public GameObject Prefab => _prefab;
    }
}