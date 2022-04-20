using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameOverHandler : NetworkBehaviour
{
    public static event Action<string> ClientOnGameOver;

    List<PlayerName> players = new List<PlayerName>();

    public override void OnStartServer()
    {
        PlayerConfig.ServerOnPlayerSpawned += ServerHandlePlayerSpawned;
        PlayerConfig.ServerOnPlayerDespawned += ServerHandlePlayerDespawned;
    }

    public override void OnStopServer()
    {
        PlayerConfig.ServerOnPlayerSpawned -= ServerHandlePlayerSpawned;
        PlayerConfig.ServerOnPlayerDespawned -= ServerHandlePlayerDespawned;
    }

    void ServerHandlePlayerSpawned(PlayerName player)
    {
        players.Add(player);
    }

    void ServerHandlePlayerDespawned(PlayerName player)
    {
        players.Remove(player);
        if (players.Count != 1) return;
        RpcGameOver(players[0].Name);
    }

    [ClientRpc]
    void RpcGameOver(string winner)
    {
        ClientOnGameOver?.Invoke(winner);
    }
}
