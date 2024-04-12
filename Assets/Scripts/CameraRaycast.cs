using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 6))
            {
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }

    
}
