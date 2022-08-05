using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private CircleMapPointsGenerator _pointGenerator;
        [SerializeField] private ObjectsData _objData;
        private LinkedList<GameObject> _spawnedObjects;
        public void Generate()
        {
            if (_spawnedObjects is null)
                _spawnedObjects = new LinkedList<GameObject>();
            ClearObjects();
            var points = _pointGenerator.GeneratePoints();
            foreach (var point in points)
            {
                var dataForSpawn = _objData.TakeRandomObjectByItsChance();
                var instance = Instantiate(dataForSpawn.gameObject,point + dataForSpawn.offSet, Quaternion.identity);
                _spawnedObjects.AddFirst(instance);
            }
        }

        private void ClearObjects()
        {
            foreach (var obj in _spawnedObjects)
                Destroy(obj);
            _spawnedObjects.Clear();
        }
    }   
}
