using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Inputs
{
    public struct InputAxis
    {
        public float HorizontalInput;
        public float VerticalInput;
    }

    public struct HoldMouseInformation
    {
        public bool IsHit;
        public RaycastHit RaycastHit;
    }

    public abstract class InputShell : MonoBehaviour
    {
        public UnityEvent<InputAxis> UpdateAxisEvent;
        public UnityEvent RightArrowButtonDownEvent;
        public UnityEvent LeftArrowButtonDownEvent;
        public UnityEvent<HoldMouseInformation> HoldMouseButtonEvent;
        public UnityEvent MouseButtonUpEvent;
    }
}
