using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Inputs
{
    public struct InputAxis
    {
        public float horizontalInput;
        public float verticalInput;
    }

    public abstract class InputShell : MonoBehaviour
    {
        public UnityEvent<InputAxis> UpdateAxisEvent;
    }
}
