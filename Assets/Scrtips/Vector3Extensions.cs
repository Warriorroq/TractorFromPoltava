using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 Range(this Vector3 min, Vector3 to)
        => new Vector3(Random.Range(min.x,to.x), Random.Range(min.y,to.y), Random.Range(min.z,to.z));
}