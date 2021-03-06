using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Spawners
{
    public class SpawnableObject : MonoBehaviour
    {
        [HideInInspector] public UnityEvent OnDestroyEvent;
        
        private void OnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }
    }
}
