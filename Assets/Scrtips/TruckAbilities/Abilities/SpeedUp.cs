using UnityEngine;
namespace TruckAbilities.Abilities
{
    [CreateAssetMenu(fileName = "SpeedUp", menuName = "SpeedUp",order = 2)]
    public class SpeedUp : Ability
    {
        [SerializeField] private float _force;

        protected override void OnUse(Transform owner)
        {
            var carController = owner.GetComponent<Rigidbody>();
            carController.AddRelativeForce(_force * Vector3.forward);
            Debug.Log("Speed Up");
        }
    }
}
