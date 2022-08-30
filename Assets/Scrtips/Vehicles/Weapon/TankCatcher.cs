using UnityEngine;
using Vehicles.Tank;

namespace Vehicles.Weapon
{
    public class TankCatcher : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<TankBrain>(out var brain))
            {
                brain.enabled = false;
                brain.transform.SetParent(transform, false);
                Destroy(brain.GetComponent<Rigidbody>());
            }
        }
    }
}
