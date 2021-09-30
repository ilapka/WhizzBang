using System;
using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Interfaces;
using WhizzBang.Spawners;
using WhizzBang.UI;

namespace WhizzBang.Enemies
{
    public class Enemy : SpawnableObject, IHaveHealth
    {
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private ParticleSystem dieEffect;

        public int Health { get; private set; }
        private bool _died;

        private void Start()
        {
            Health = enemyData.health;
        }

        public void TakeDamage(int damage)
        {
            if(_died) return;
            
            Health -= damage;
            if (Health <= 0f)
            {
                Die();
            }
            
            PopUpManager.Instance.CreatePopUpText(damage.ToString(), transform.position);
        }
        
        private void Die()
        {
            _died = true;
            dieEffect.gameObject.SetActive(true);
            dieEffect.Play();
            Destroy(gameObject, dieEffect.main.duration);
        }
    }
}
