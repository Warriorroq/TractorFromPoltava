using System;
using UnityEngine;

namespace MapGeneration
{
    //[RequireComponent(typeof(Rigidbody))]
    public class SpawnableObjectData : MonoBehaviour
    {
        public int priority;
        [SerializeField] private Vector3 _boxSize;
        [SerializeField] private Vector3 _boxOffSet;
        private void Start()
        {
            var cast = Physics.BoxCastAll(transform.position + _boxOffSet, _boxSize, Vector3.up);
            foreach (var collider in cast)
            {
                if (collider.collider.TryGetComponent<SpawnableObjectData>(out var data))
                    ResolveConflict(data);
            }
        }
        private void ResolveConflict(SpawnableObjectData spawnedDataObject)
        {
            if (spawnedDataObject.transform.IsChildOf(transform))
                return;
            if (spawnedDataObject.priority <= priority)
            {
                Destroy(spawnedDataObject.gameObject);
                if(TryGetComponent<Rigidbody>(out var rb))
                    rb.velocity = Vector3.zero;
            }
        }
    }
}