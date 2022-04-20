using Mirror;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] GameObject cam;

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        cam.SetActive(true);
    }
}
