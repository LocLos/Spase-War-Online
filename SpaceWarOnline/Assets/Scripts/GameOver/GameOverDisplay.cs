using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Text winnerNameText;

    void Start()
    {
        GameOverHandler.ClientOnGameOver += ClientHandleGameOver;
        canvas.SetActive(false);

    }

    void OnDestroy()
    {
        GameOverHandler.ClientOnGameOver -= ClientHandleGameOver;
    }

    void ClientHandleGameOver(string winner)
    {
        canvas.SetActive(true);
        winnerNameText.text = $"{winner} победил!";
    }

    public void RestartGame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
            NetworkManager.singleton.StopHost();
        else NetworkManager.singleton.StopClient();
        canvas.SetActive(false);
    }
}
