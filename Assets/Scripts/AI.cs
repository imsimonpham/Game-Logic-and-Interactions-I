using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;

public class AI : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentIndex = 0;
    private bool _reversedPath = false;
    private enum AIState
    {
        Walk, 
        Jump,
        Attack
    }

    [SerializeField] private AIState _currentState;
    private bool _isAttacking = false;
    private bool _isJumping = false;
    private MeshRenderer _renderer;
    private Color _originalColor;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if(_agent != null)
        {
            _agent.destination = _wayPoints[_currentIndex].position;
        }

        _renderer = GetComponent<MeshRenderer>();
        _originalColor = _renderer.material.color;
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentState = AIState.Jump;
        }

        switch (_currentState)
        {
            case AIState.Walk:
                CalculateAIMovement();
                break;
            case AIState.Jump:
                Debug.Log("Jumping...");
                if (!_isJumping)
                {
                    StartCoroutine(JumpRoutine());
                    _isJumping = true;
                }
                break;
            case AIState.Attack:
                Debug.Log("Attacking...");
                if (!_isAttacking)
                {
                    StartCoroutine(AttackRoutine());
                    _isAttacking = true;
                }
                break;
        }
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
            _agent.SetDestination(_wayPoints[_currentIndex].position);
            _currentState = AIState.Attack;
        }
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

    IEnumerator AttackRoutine()
    {
        _agent.isStopped = true;
        _renderer.material.color = Color.blue;
        yield return new WaitForSeconds(2f);
        _agent.isStopped = false;
        _renderer.material.color = _originalColor;
        _currentState = AIState.Walk;
        _isAttacking = false;
    }

    IEnumerator JumpRoutine()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        _agent.isStopped = false;
        _currentState = AIState.Walk;
        _isJumping = false;
    }
}
