using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private CircleMapPointsGenerator _pointGenerator;
        [SerializeField] private ObjectsData _objData;
        void Start()
        {
            var points = _pointGenerator.GeneratePoints();
            foreach (var point in points)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = point;
            }
        }
    }   
}
