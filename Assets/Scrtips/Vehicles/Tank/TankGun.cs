using UnityEngine;

namespace Vehicles.Tank
{
    public class TankGun : MonoBehaviour
    {
        private Vector3 _direction;
        private bool _isLooking;
        [SerializeField] private float _rotatingSpeed;
        private Transform _parent;

        public void ResetLookDirection()
            =>SetLookDirection(_parent.forward + transform.position);
        public void SetLookDirection(Transform obj)
            =>_direction = new Vector3(obj.position.x, transform.position.y, obj.position.z);
        public void SetLookDirection(Vector3 direction)
            =>_direction = direction;
        public void LookAtSettedDirection()
            =>_isLooking = true;
        private void Awake()
        {
            if (_parent is null)
                _parent = transform.parent;
            ResetLookDirection();
            LookAtSettedDirection();
        }
        private void Update()
        {
            if (_isLooking)
            {
                var temp = transform.rotation;
                transform.LookAt(_direction);
                transform.rotation = Quaternion.Slerp(temp, transform.rotation, Time.deltaTime * _rotatingSpeed);
                _isLooking = false;
            }
        }
    }   
}
