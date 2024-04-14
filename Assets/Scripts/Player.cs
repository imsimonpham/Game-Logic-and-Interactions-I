using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float _speed = 5f;

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _targetPosition);
        if(distance > 1f)
        {
            var dir = _targetPosition - transform.position;
            dir.Normalize();
            transform.Translate(dir * _speed * Time.deltaTime);
        }
    }

    public void UpdatePosition(Vector3 targetPosition)
    {
        //lock the y position
        targetPosition.y = 1f;
        _targetPosition = targetPosition;
    }
}
