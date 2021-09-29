using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Inputs
{
    public struct InputAxis
    {
        public float HorizontalInput;
        public float VerticalInput;
    }

    public abstract class InputShell : MonoBehaviour
    {
        public UnityEvent<InputAxis> UpdateAxisEvent;
    }
}
