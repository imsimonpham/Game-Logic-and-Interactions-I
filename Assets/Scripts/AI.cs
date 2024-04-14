using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentIndex = 0;
    private bool _reversedPath = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if(_agent == null)
        {
            Debug.LogError("Nav Mesh agent is null");
        }
    }

    private void Update()
    {
        CalculateAIMovement();
    }

    void CalculateAIMovement()
    {
        if (_agent.remainingDistance < 1f)
        {
            if (!_reversedPath)
            {
                MoveForward();
            }
            else
            {
                MoveReverse();
            }
        }
        _agent.SetDestination(_wayPoints[_currentIndex].transform.position);
    }

    void MoveForward()
    {
        if (_currentIndex == _wayPoints.Count - 1)
        {
            _reversedPath = true;
            _currentIndex--;
        }
        else
        {
            _currentIndex++;
        }
    }

    void MoveReverse()
    {
        if (_currentIndex == 0)
        {
            _reversedPath = false;
            _currentIndex++;
        }
        else
        {
            _currentIndex--;
        }
    }
}
