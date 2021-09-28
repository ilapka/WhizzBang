using System;
using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Interfaces;
using WhizzBang.Spawners;

namespace WhizzBang.Enemies
{
    public class Enemy : SpawnableObject, IHaveHealth
    {
        [SerializeField] private EnemyData enemyData;
        public float Health { get; private set; }

        private void Start()
        {
            Health = enemyData.health;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0f)
            {
                Die();
            }
        }
        
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
