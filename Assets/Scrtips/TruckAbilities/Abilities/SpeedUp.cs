using UnityEngine;
namespace TruckAbilities
{
    [CreateAssetMenu(fileName = "SpeedUp", menuName = "SpeedUp",order = 2)]
    public class SpeedUp : Ability
    {
        [SerializeField] private float _force;

        protected override void OnUse(Transform owner)
        {
            var carController = owner.GetComponent<CarController>();
            carController.SetAdditionalMotorForce(_force);
            Debug.Log("Speed Up");
        }
    }
}
