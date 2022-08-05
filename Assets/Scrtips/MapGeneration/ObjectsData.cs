using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapGeneration
{
    [CreateAssetMenu(fileName = "SpawnObjectsData", menuName = "MapGeneration", order = 0)]
    public class ObjectsData : ScriptableObject
    {
        [SerializeField] private List<SpawningData> _objectsData;
        public void OnValidate()
            =>_objectsData.Sort();

        public SpawningData TakeRandomObjectByItsChance()
        {
            var value = Random.value;
            foreach (var data in _objectsData)
            {
                if (value <= data.chance)
                    return data;
            }
            throw new Exception($"There is no data to {value} in {this.name}");
        }
        [Serializable]
        public class SpawningData : IComparable<SpawningData>
        {
            public GameObject gameObject;
            public Vector3 offSet;
            [Range(0,1f)] public float chance;
            public int CompareTo(SpawningData other)
                =>chance.CompareTo(other.chance);
        }
    }
}