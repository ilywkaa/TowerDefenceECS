using System;
using UnityEngine;

namespace TowerDefence
{
    public class AStarPathfindingService : IPathfindingService
    {
        public Transform _target;
        public AStarPathfindingService(IConfigurationService configuration)
        {
            var targets = GameObject.FindGameObjectsWithTag(configuration.Game.TargetPrefab.tag);
            if (targets.Length == 0)
                throw new NullReferenceException("There are no targets in current scene.");
            else if(targets.Length > 1)
                throw new NullReferenceException("Game logic for more than one target is not implemented.");
            else
                _target = targets[0].transform;
        }

        public Transform Target()
        {
            return _target;
        }
    }
}