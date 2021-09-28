using UnityEngine;
using UnityEngine.Events;

namespace WhizzBang.Spawners
{
    public class SpawnableObject : MonoBehaviour
    {
        [HideInInspector] public UnityEvent onDestroyEvent;
        
        private void OnDestroy()
        {
            onDestroyEvent.Invoke();
        }
    }
}
