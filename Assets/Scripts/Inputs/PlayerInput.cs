using System;
using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Inputs
{
    public class PlayerInput : InputShell
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float mouseRayLenght;
        
        private void FixedUpdate()
        {
            UpdateAxisInput();
        }

        private void UpdateAxisInput()
        {
            UpdateAxisEvent.Invoke(new InputAxis()
            {
                HorizontalInput = Input.GetAxis("Horizontal"),
                VerticalInput = Input.GetAxis("Vertical"),
            });
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
                LeftArrowButtonDownEvent.Invoke();
            
            if(Input.GetKeyDown(KeyCode.RightArrow))
                RightArrowButtonDownEvent.Invoke();

            if (Input.GetMouseButton(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                var holdMouseInformation = new HoldMouseInformation()
                {
                    IsHit = Physics.Raycast(ray, out RaycastHit hit, mouseRayLenght),
                    RaycastHit = hit,
                };
                HoldMouseButtonEvent.Invoke(holdMouseInformation);
            }

            if (Input.GetMouseButtonUp(0))
            {
                MouseButtonUpEvent.Invoke();
            }

            if (Input.GetMouseButtonDown(0))
            {
                MouseButtonDownEvent.Invoke();
            }
        }
    }
}
