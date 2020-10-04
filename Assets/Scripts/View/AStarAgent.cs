using Pathfinding;
using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(Seeker),typeof(AIPath), typeof(CharacterController))]
    public class AStarAgent : MonoBehaviour, IAgent
    {
		private Transform _target;
        private IAstarAI _ai;

        void OnEnable()
        {
            _ai = GetComponent<IAstarAI>();
            if (_ai != null) _ai.onSearchPath += Update;
        }
        void OnDisable()
        {
            if (_ai != null) _ai.onSearchPath -= Update;
        }
        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            if (_target != null && _ai != null) _ai.destination = _target.position;
        }
        public void SetDestination(Transform target)
        {
            _target = target;
        }
    }
}