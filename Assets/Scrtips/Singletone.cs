using System;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (_instance)
                return _instance;
            var objs = FindObjectsOfType<T>();
            if (objs.Length > 1)
                throw new Exception($"Many singletones {typeof(T)}");
            if(objs.Length == 0)
                throw new Exception($"Any singletone {typeof(T)}");
            _instance = objs[0];
            return _instance;
        }
    }
    private static T _instance;
}
