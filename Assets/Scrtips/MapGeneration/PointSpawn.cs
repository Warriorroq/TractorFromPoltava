using UnityEngine;

namespace MapGeneration
{
    public class PointSpawn : MonoBehaviour
    {
        [SerializeField] private ObjectsData _objData;
        private void Awake()
        {
            var parent = transform.parent;
            var dataForSpawn = _objData.TakeRandomObjectByItsChance();
            var instance = Instantiate(dataForSpawn.gameObject,transform.position + dataForSpawn.offSet, Quaternion.identity);
            instance.transform.parent = parent;
        }
    }
}
