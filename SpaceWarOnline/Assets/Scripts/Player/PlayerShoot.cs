using UnityEngine;
using Mirror;
using System.Collections;

[RequireComponent(typeof(PlayerConfig))]
public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] 
    private Bullet _bulletPrefab;
    [SerializeField]
    private Transform[] _bulletSpawnPos = new Transform[2];
    [SerializeField]
    private PlayerConfig _playerConfig;

    [ClientCallback]
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BulletSpawn();
            }
        }
    }
    [ServerCallback]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NetworkIdentity networkIdentity)
            && networkIdentity.connectionToClient == connectionToClient)
            return;
       // BulletSpawn();

    }
    [Command]
    void BulletSpawn()
    {
        foreach (var pos in _bulletSpawnPos)
        {
            var bulletInstance = Instantiate(_bulletPrefab, pos.position, pos.rotation);
            bulletInstance.SetDamage(_playerConfig.Damage);
            NetworkServer.Spawn(bulletInstance.gameObject, connectionToClient);
        }
    }
    IEnumerator DelayedDestroy(GameObject obj, float delay)
    {

        yield return new WaitForSeconds(delay);

        NetworkServer.Destroy(obj);

    }
}
