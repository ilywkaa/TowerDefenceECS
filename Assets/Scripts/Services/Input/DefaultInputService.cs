using System;
using UnityEngine;

namespace TowerDefence
{
    public class DefaultInputService : IInputService
    {
        private bool _buttonDown;
        private GameObject _selectedObject;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                { 
                    _buttonDown = true;
                    if (hit.collider != null)
                    {
                        _selectedObject = hit.collider.gameObject;
                    }
                    else if (hit.rigidbody != null)
                    {
                        _selectedObject = hit.rigidbody.gameObject;
                    }
                }
            }
            else
            {
                _buttonDown = false;
            }
        }

        public bool Click()
        {
            Update();
            return _buttonDown;
        }

        public GameEntity GetClicked()
        {
            if(_buttonDown) return _selectedObject.GetComponent<IView>()?.Entity;
            throw new NullReferenceException("You call GetClicked in Input system without checking Click method.");
        }
    }
}