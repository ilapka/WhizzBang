using System;
using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Inputs
{
    public class PlayerInput : InputShell
    {
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
            
            if(Input.GetMouseButton(0))
                HoldMouseButtonEvent.Invoke();
            
            if(Input.GetMouseButtonUp(0))
                MouseButtonUpEvent.Invoke();
        }
    }
}
