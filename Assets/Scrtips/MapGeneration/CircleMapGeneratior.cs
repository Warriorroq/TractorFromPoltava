using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapGeneration
{
    public class CircleMapGeneratior : UnityEngine.MonoBehaviour
    {
        [SerializeField] private int _minGeneratedObjects;
        [SerializeField] private int _maxGeneratedObjects;
        [SerializeField] private float _minGeneratedDistance;
        [SerializeField] private float _maxGeneratedDistance;
        private LinkedList<GameObject> _generatedGameObjects;

        public void Update()
        {
            Generate();
        }

        public void Generate()
        {
            if (_generatedGameObjects is null)
                _generatedGameObjects = new LinkedList<GameObject>();
            DestroyGeneratedObjects();
            for (float i = 0; i < 360.5f; i += 0.5f)
            {
                Vector3 direction = new Vector3(Mathf.Sin(i), 0, Mathf.Cos(i));
                GenerateObjectsInDirection(direction);
            }
        }
        public void DestroyGeneratedObjects()
        {
            foreach (var obj in  _generatedGameObjects)
                Destroy(obj);
            _generatedGameObjects.Clear();
        }

        private void GenerateObjectsInDirection(Vector3 direction)
        {
            var objects = Random.Range(_minGeneratedObjects, _maxGeneratedObjects);
            for (int i = 0; i < objects;i++)
            {
                var location = direction * Random.Range(_minGeneratedDistance, _maxGeneratedDistance);
                var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = location;
                _generatedGameObjects.AddFirst(obj);
            }
        }
    }
}