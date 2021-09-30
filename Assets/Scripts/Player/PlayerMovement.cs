﻿using System;
using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Inputs;

namespace WhizzBang.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputShell inputShell;
        [SerializeField] private Rigidbody rootRigidbody;
        [SerializeField] private CapsuleCollider rootCollider;
        [SerializeField] private MovementData movementData;
        
        private float _stoppingMaxDistance;

        void Start()
        {
            _stoppingMaxDistance = rootCollider.radius * 1.1f;
            inputShell.UpdateAxisEvent.AddListener(Move);
        }

        private void Move(InputAxis inputAxis)
        {
            var moveDirection = new Vector3(inputAxis.HorizontalInput, 0f, inputAxis.VerticalInput).normalized;
            var acceleration = Mathf.Clamp(Mathf.Abs(inputAxis.HorizontalInput) + Mathf.Abs(inputAxis.VerticalInput), 0f, 1f); 

            if(!Physics.Raycast(rootRigidbody.position, moveDirection, out RaycastHit hitInfo, _stoppingMaxDistance, movementData.obstaclesLayerMask))
            {
                rootRigidbody.MovePosition(rootRigidbody.position + moveDirection * Time.deltaTime * movementData.speed * acceleration);
            }
            else
            {
                rootRigidbody.velocity = Vector3.zero;
            }
        }

        private void OnDestroy()
        {
            inputShell.UpdateAxisEvent.RemoveListener(Move);
        }
    }
}
