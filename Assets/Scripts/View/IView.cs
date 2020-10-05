using Entitas;
using UnityEngine;

namespace TowerDefence
{
    public interface IView
    {
        bool Enabled { get; set; }
        Transform Transform { get; }
        GameEntity Entity { get; }
        void InitializeView(Contexts contexts, GameEntity entity);
        Collider Collider { get; }
    }
}