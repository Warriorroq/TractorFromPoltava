using UnityEngine;
namespace TruckAbilities.Abilities
{
    [CreateAssetMenu(fileName = "BigJump", menuName = "BigJump", order = 1)]
    public class BigJump : Ability
    {
        [SerializeField] private float _force;
        protected override void OnUse(Transform owner)
        {
            owner.GetComponent<Rigidbody>().AddForce(owner.up*_force + owner.forward * _force/4);
            Debug.Log("Jump");
        }
    }
}
