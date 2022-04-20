using UnityEngine;
using System;

public class PlayersHealth : MonoBehaviour, IHealth
{
    [SerializeField] private StateHealth _stateHealth;

    public event Action HealthChanged;

    public int Current
    {
        get => _stateHealth.CurrentHP;
        set
        {
            if (value != _stateHealth.CurrentHP)
            {
                _stateHealth.CurrentHP = value;

                HealthChanged?.Invoke();
            }
        }
    }

    public int Max
    {
        get => _stateHealth.MaxHP;
        set => _stateHealth.MaxHP = value;
    }

    public void TakeDamage(int damage)
    {
        if (Current <= 0)
            return;

        Current -= damage;
    }
}