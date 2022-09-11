using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthBehavior : MonoBehaviour
{
    public UnityEvent<float> onHealthChanged;
    public UnityEvent<HealthBehavior> onDestroy;
    public float Health
    {
        set
        {
            if (value < 0)
            {
                _health = 0;
                onDestroy.Invoke(this);
                return;
            }
            _health = value;
            onHealthChanged.Invoke(_health);
        }
        get => _health;
    }
    private float _health;
    public void DestroyThisGameObject()
        => Destroy(gameObject);
    public void DestroyThis()
        => Destroy(this);
}
