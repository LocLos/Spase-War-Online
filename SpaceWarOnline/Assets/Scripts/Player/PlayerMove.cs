using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerConfig))]

public class PlayerMove : NetworkBehaviour
{
    private const string Vertical = "Vertical";

    [SerializeField] PlayerConfig _playerStates;
    
    [SyncVar]
    private int _speedRotate=1;
    [SyncVar]
    private int _speed;
    [SerializeField] Rigidbody2D _rigidbody2D;
    public override void OnStartServer()
    {
        _speed=_playerStates.Speed;
       // _playerStates.onChangeSpeed += ChangeSpeed;
      //  _rigidbody2D=GetComponent<Rigidbody2D>();
    }
    public override void OnStopServer()
    {
  //      _playerStates.onChangeSpeed -= ChangeSpeed;
    }

    private void ChangeSpeed(int speed)
    {
        _speed=speed;
    }

    [ClientCallback]
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _rigidbody2D.AddForce(transform.up * _speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody2D.AddForce(-transform.up * _speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.AddTorque(_speedRotate, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.AddTorque(-_speedRotate, ForceMode2D.Impulse);
            }
        }
    }
}
