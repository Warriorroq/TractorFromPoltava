using System;
using UnityEngine;

namespace TruckAbilities
{
    public class AbilityController : MonoBehaviour
    {
        public Ability mainAbility;
        public Ability additionAbility;
        private void Update()
        {
            mainAbility?.Reload();
            additionAbility?.Reload();
        }

        public void UseMainAbility()
            => mainAbility.Use(transform);
        public void UseAdditionalAbility()
            => additionAbility.Use(transform);
    }
}
