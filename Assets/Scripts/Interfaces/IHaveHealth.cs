using UnityEngine;

namespace WhizzBang.Interfaces
{
    public interface IHaveHealth
    {
        int Health { get; }
        void TakeDamage(int damage);
    }
}
