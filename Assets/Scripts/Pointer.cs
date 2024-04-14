using UnityEngine.InputSystem;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is null");
        }
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.name == "Floor")
                {
                    _player.UpdatePosition(hitInfo.point);
                }
            }
        }
    }
}
