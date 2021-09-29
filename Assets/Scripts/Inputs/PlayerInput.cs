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
                horizontalInput = Input.GetAxis("Horizontal"),
                verticalInput = Input.GetAxis("Vertical"),
            });
        }
    }
}
