using System;
using UnityEngine;

namespace Effects
{
    public class Pusher : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private Vector3 _direction;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Rigidbody>(out var rb))
            {
                var direction = rb.transform.TransformDirection(transform.TransformDirection(_direction));
                rb.AddRelativeForce(direction * _force);   
            }
        }
    }
}