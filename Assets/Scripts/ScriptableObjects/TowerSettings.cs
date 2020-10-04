using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "InitialTowerSettings", menuName = "ScriptableObjects/TowerSettings", order = 3)]
    public class TowerSettings : ScriptableObject
    {
        [Min(1f)] 
        [SerializeField] 
        private int _damage;
        [Min(1f)]
        [SerializeField]
        private int _fireRate;
        [SerializeField]
        private GameObject _prefab;

        public int FireRate => _fireRate;
        public int Damage => _damage;
        public GameObject Prefab => _prefab;
    }
}