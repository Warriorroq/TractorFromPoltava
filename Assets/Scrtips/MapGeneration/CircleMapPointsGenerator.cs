using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    [System.Serializable]
    public class CircleMapPointsGenerator
    {
        [SerializeField] private MinMax<int> _countOfPoints;
        [SerializeField] private MinMax<int> _spawnDistance;
        public List<Vector3> GeneratePoints(Vector3 startPosition = new Vector3())
        {
            List<Vector3> points = new List<Vector3>();
            for (float i = 0; i < 360.5f; i += 0.5f)
            {
                Vector3 direction = new Vector3(Mathf.Sin(i), 0, Mathf.Cos(i));
                var numberOfPointsInDirection = Random.Range(_countOfPoints.min, _countOfPoints.max);
                for (int j = 0; j < numberOfPointsInDirection;j++)
                    points.Add(startPosition + direction * Random.Range(_spawnDistance.min, _spawnDistance.max));
            }
            return points;
        }
    }
}