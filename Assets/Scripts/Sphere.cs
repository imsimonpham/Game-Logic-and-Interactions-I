using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {   
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position, Vector3.down * 3f, Color.yellow);
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 3f))
        {
            if(hitInfo.collider.name == "Floor")
            {
                _rb.useGravity = false;
                _rb.isKinematic = true;
            }
        }
    }
}
