using UnityEngine;
using Vehicles.Tank;

namespace Vehicles.Weapon
{
    public class TankCatcher : MonoBehaviour
    {
        public TankBrain _target;
        public void DropTank()
        {
            _target.transform.SetParent(null);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<TankBrain>(out var brain) && !_target)
            {
                brain.enabled = false;
                brain.transform.SetParent(transform, false);
                Destroy(brain.GetComponent<Rigidbody>());
                _target = brain;
            }
        }
    }
}
