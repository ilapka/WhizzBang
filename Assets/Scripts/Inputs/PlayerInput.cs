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
    }
}
