using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceWarNetworkManager : NetworkManager
{
    [SerializeField] Transform spawnPoint1, spawnPoint2, spawnPoint3;
    [SerializeField] GameObject _gameOverHandler;
    public override void OnStartServer()
    {
        var gameOverHandler = Instantiate(_gameOverHandler);
        NetworkServer.Spawn(gameOverHandler);
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform start = transform;
        switch (numPlayers)
        {
            case 0: start = spawnPoint1; break;
            case 1: start = spawnPoint2; break;
            case 2: start = spawnPoint3; break;
            default: start = spawnPoint1; break;
        }
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

    }
}
