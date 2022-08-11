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
            ClearObjects();
            var points = _pointGenerator.GeneratePoints();
            foreach (var point in points)
            {
                var dataForSpawn = _objData.TakeRandomObjectByItsChance();
                var instance = Instantiate(dataForSpawn.gameObject,point + dataForSpawn.offSet, Quaternion.identity);
                if (dataForSpawn.isRandomizedRotation)
                {
                    var angleRot = instance.transform.eulerAngles;
                    instance.transform.rotation = Quaternion.Euler(angleRot.x,Random.Range(0,360f),angleRot.y);   
                }
                _spawnedObjects.AddFirst(instance);
            }
        }

        public void ClearObjects()
        {
            if (_spawnedObjects is null)
                _spawnedObjects = new LinkedList<GameObject>();
            foreach (var obj in _spawnedObjects)
                Destroy(obj);
            _spawnedObjects.Clear();
        }
    }   
}
