using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletHolePrefab;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            float hitPointOffset = 0.01f;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Vector3 hitPoint = hitInfo.point;
                hitPoint.z -= hitPointOffset;
                Instantiate(_bulletHolePrefab, hitPoint, Quaternion.Euler(0f, 180f, 0f));
            }
        }
    }
}
