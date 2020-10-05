using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyAttackSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly Collider _targetCollider;
        private readonly float _attackDistance;
        private float _timer = 5;
        private float _attackTime = 1f;
        public EnemyAttackSystem(Contexts contexts, IPathfindingService pathfindingService , float attackDistance = 10f)
        {
            _context = contexts.game;
            _targetCollider = pathfindingService.Target().GetComponent<Collider>();
            _attackDistance = attackDistance;
        }
        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _attackTime;
                var enemies =
                    _context.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Agent)).GetEntities();
                foreach (var enemy in enemies)
                {
                    var targetClosestPoint = _targetCollider.ClosestPoint(enemy.position.value);
                    var enemyClosestPoint = enemy.view.value.Collider.ClosestPoint(_targetCollider.transform.position);

                    //Debug.Log($"Enemy {enemy.view.value.Transform.name} is far {(enemy.position.value - _targetCollider.transform.position).magnitude} from target.");
                    //Debug.Log($"Enemy {enemy.view.value.Transform.name} is far {(enemyClosestPoint - targetClosestPoint).magnitude} from target.");

                    if ((enemy.position.value - _targetCollider.transform.position).magnitude < _attackDistance)
                    //if ((targetClosestPoint - enemyClosestPoint).magnitude < _attackDistance)
                    {
                        enemy.AddHit(enemy.damage.value);
                    }
                }
            }
        }
    }
}