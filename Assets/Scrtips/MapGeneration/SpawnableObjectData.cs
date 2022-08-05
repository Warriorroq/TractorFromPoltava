using System;
using UnityEngine;

namespace MapGeneration
{
    public class SpawnableObjectData : MonoBehaviour
    {
        public int priority;
        private void Start()
        {
            Destroy(this);
        }
        private void OnCollisionEnter(Collision collision)
        {
            var data = collision.gameObject.GetComponent<SpawnableObjectData>();
            if (data is not null)
                ResolveConflict(data);
        }
        private void ResolveConflict(SpawnableObjectData data)
        {
            if(data.priority < priority)
                Destroy(data.gameObject);
        }
    }
}