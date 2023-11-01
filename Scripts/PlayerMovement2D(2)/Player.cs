using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _playerHealth;

    public void ApplyDamage(int damage)
    {
        _playerHealth -= damage;

        if ( _playerHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}