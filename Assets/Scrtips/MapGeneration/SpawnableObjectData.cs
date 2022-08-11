using System;
using UnityEngine;

namespace MapGeneration
{
    //[RequireComponent(typeof(Rigidbody))]
    public class SpawnableObjectData : MonoBehaviour
    {
        public int priority;
        [SerializeField] private Rigidbody _rigitbody;
        [SerializeField] private bool _destroyRigitbody;
        private void Start()
        {
            Destroy(this);
            if(_destroyRigitbody)
                Destroy(_rigitbody);
        }
        private void OnTriggerEnter(Collider other)
        {
            var spawnedDataObject = other.GetComponent<SpawnableObjectData>();
            if (spawnedDataObject is not null)
                ResolveConflict(spawnedDataObject);
            GetComponent<Collider>().isTrigger = false;
        }

        private void ResolveConflict(SpawnableObjectData spawnedDataObject)
        {
            if (spawnedDataObject.priority <= priority)
            {
                //Debug.Log($"{name} is removing {spawnedDataObject.gameObject.name} cuz of conflict");
                Destroy(spawnedDataObject.gameObject);
                _rigitbody.velocity = Vector3.zero;
            }
        }
    }
}