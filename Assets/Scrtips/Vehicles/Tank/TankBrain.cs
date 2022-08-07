using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Vehicles.Tank
{
    public class TankBrain : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _target;
        [SerializeField] private float _sqrtArgDistance;
        [SerializeField] private TankGun _head; 

        public void MoveToTarget()
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.position);
        }
        public void StopMoving()
        {
            _agent.isStopped = true;
        }
        private void Update()
        {
            var temp = _target.position - transform.position;
            if (temp.sqrMagnitude > _sqrtArgDistance)
            {
                _head.ResetLookDirection();
                _head.LookAtSettedDirection();
                MoveToTarget();
            }
            else
            {
                StopMoving();
                _head.SetLookDirection(_target);
                _head.LookAtSettedDirection();
            }
        }
    }
}