using UnityEngine;
using Mirror;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : NetworkBehaviour
{

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;

    [Header("Stats")]
    [SerializeField] float destroyAfter = 5;
    [SerializeField] float force = 1000;
    private int _damage;

    public void SetDamage(int dmg)
    {
        _damage = dmg;
    }
    public override void OnStartServer()
    {
        print(1);
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    public override void OnStartClient()
    {
        print(2);
        rb.AddForce(transform.up * force);
    }

    [ServerCallback]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NetworkIdentity networkIdentity)
            && networkIdentity.connectionToClient == connectionToClient)
            return;

        if (collision.TryGetComponent(out IHealth health))
        {
            health.TakeDamage(-_damage);
        }
        DestroySelf();
    }

    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

}
