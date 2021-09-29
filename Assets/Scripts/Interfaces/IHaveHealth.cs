using UnityEngine;

namespace WhizzBang.Interfaces
{
    public interface IHaveHealth
    {
        float Health { get; }
        void TakeDamage(float damage);
    }
}
