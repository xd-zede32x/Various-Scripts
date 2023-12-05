using System;
using UnityEngine;

public class GoodExample : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Transform _transform;

    public bool IsAlive => _health >= 0;
    public float Health => _health;

    private void ApplyDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health -= damage;
    }

    private void Died()
    {
        if (_health <= 0)
            Destroy(gameObject);
    }
}