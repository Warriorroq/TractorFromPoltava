using UnityEngine;
using UnityEngine.Events;

namespace TruckAbilities
{
    [CreateAssetMenu(fileName = "AbilityAbstract", menuName = "Abilities", order = 0)]
    public abstract class Ability : ScriptableObject
    {
        public UnityEvent<float> getTimeForReload;
        public UnityEvent ready;
        public UnityEvent onUse;
        public bool isReady;
        [SerializeField]private float _reloadTime;
        private float _elapsedTime;
        public void Use(Transform owner)
        {
            onUse.Invoke();
            if (isReady)
            {
                isReady = false;
                OnUse(owner);
            }
        }
        protected abstract void OnUse(Transform owner);
        public void Reload()
        {
            if (_elapsedTime >= _reloadTime)
            {
                _elapsedTime = 0;
                isReady = true;
                ready.Invoke();
            }
            else if(!isReady)
            {
                _elapsedTime += Time.deltaTime;
                getTimeForReload.Invoke(_reloadTime - _elapsedTime);
            }
        }
    }
}
