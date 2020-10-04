using UnityEngine;

namespace TowerDefence
{
    public interface IInputService
    {
        bool Click();
        GameEntity GetClicked();
    }
}