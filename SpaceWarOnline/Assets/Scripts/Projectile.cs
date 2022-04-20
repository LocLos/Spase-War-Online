/*using Mirror;
using UnityEngine;

public class Projectile : NetworkBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody rb;

    [Header("Stats")]
    [SerializeField] float destroyAfter = 5;
    [SerializeField] float force = 1000;

    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    public override void OnStartClient()
    {
        rb.AddForce(transform.forward * force);
    }

    [ServerCallback]
    void OnTriggerEnter(Collider co)
    {
        DestroySelf();
    }

    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }
}
*/