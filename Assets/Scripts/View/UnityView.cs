using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(Collider))]
    public class UnityView : MonoBehaviour, IView
    {
        private GameObject _gameObject;
        private GameEntity _entity;
        public void InitializeView(Contexts contexts, GameEntity entity)
        {
            _gameObject = gameObject;
            _entity = entity;
        }


        void Update()
        {
            _entity.ReplacePosition(transform.position);
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
        public Collider Collider => gameObject.GetComponent<Collider>();
        public Transform Transform => transform;
        public GameEntity Entity => _entity;
        #endregion
    }
}