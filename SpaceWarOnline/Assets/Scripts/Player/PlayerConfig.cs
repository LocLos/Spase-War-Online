using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

public class PlayerConfig : NetworkBehaviour
{
    [SyncVar/*(hook = nameof(HandlePlayerDamageUpdated))*/]
    [SerializeField] private int _damage;
    [SyncVar/*(hook = nameof(HandlePlayerSpeedUpdated))*/]
    [SerializeField] private int _speed;
    /* [SyncVar*//*(hook = nameof(HandlePlayerHealthUpdated))*//*]
     [SerializeField] private int _health;
     */
    [SerializeField] PlayerName _playerName;

    public static event Action<PlayerName> ServerOnPlayerSpawned;
    public static event Action<PlayerName> ServerOnPlayerDespawned;

    /*public event OnChangeDamage onChangeDamage;
    public delegate void OnChangeDamage(int damage);
    public event OnChangeSpeed onChangeSpeed;
    public delegate void OnChangeSpeed(int speed);
    public event OnChangeHealth onChangeHealth;
    public delegate void OnChangeHealth(int health);

    private void HandlePlayerDamageUpdated(int oldDamage, int newDamage)
    {
        onChangeDamage?.Invoke(newDamage);
    }

    private void HandlePlayerSpeedUpdated(int oldSpeed, int newSpeed)
    {
        onChangeSpeed?.Invoke(newSpeed);
    }
    private void HandlePlayerHealthUpdated(int oldHealth, int newHealth)
    {
        onChangeHealth?.Invoke(newHealth);
    }*/


    public int Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }
    public int Damage
    {
        get { return _damage; }
        private set { _damage = value; }
    }
    /*  public int Health
      {
          get { return _health; }
          private set { _health = value; }
      }*/

    public override void OnStartServer()
    {
        ServerOnPlayerSpawned?.Invoke(_playerName);
    }

    public void ChangeSpeed(int bonusSpeed)
    {
        Speed += bonusSpeed;
    }
    public void ChangeDamage(int bonusDamage)
    {
        Damage += bonusDamage;
    }
    /*  public void ChangeHealth(int changeHealth)
     {
         Health += changeHealth;
         if (Health <= 0)
         {
             Destroy();
         }
     }*/
    /*[ServerCallback]
    private void Destroy()
    {
        NetworkServer.Destroy(gameObject);
        ServerOnPlayerDespawned?.Invoke(_playerName);

    }*/

}
