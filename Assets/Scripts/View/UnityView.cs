using UnityEngine;

namespace TowerDefence
{
    public class UnityView : MonoBehaviour, IView
    {
        private GameObject _gameObject;
        private Transform _transform;
        private GameEntity _entity;
        public void InitializeView(Contexts contexts, GameEntity entity)
        {
            _gameObject = gameObject;
            _transform = transform;
            _entity = entity;
        }

        public void OnDestroyed(GameEntity entity)
        {
            Destroy(gameObject);
        }

        #region IView implementation

        public bool Enabled
        {
            get => _gameObject.activeSelf;
            set => _gameObject.SetActive(value);
        }
        public Transform Transform => _transform;
        public GameEntity Entity => _entity;
        #endregion
    }
}