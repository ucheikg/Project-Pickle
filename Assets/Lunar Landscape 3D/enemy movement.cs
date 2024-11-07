using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class enemymovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;

    [SerializeField] private float threshholdDistance;
    // Start is called before the first frame update
    
    private enum State
    {
        Idle,
        Moving
    }
    private State _currentState = State.Idle;
    
    void Awake()
    {
        try
        {
            _agent = GetComponent<NavMeshAgent>();
        }   
        catch (Exception e) 
        {

            Debug.Log($"Exception: {e}, message: {e.Message}");
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case State.Idle:
                break;
            case State.Moving:
                break;
            default:
                break;
        }
    }

    private void Idle()
    {
        if ( ThresholdCheck(transform.position, _target.position))
        {
            _currentState = State.Moving;
        }
    }

    private void Move()
    {
        if (ThresholdCheck(transform.position, _target.position))
        {
            _agent.SetDestination(_target.position);
        }
        else
        {
            _agent.SetDestination(transform.position);
            _currentState = State.Idle;
        }
    }

    private bool ThresholdCheck(Vector3 agent, Vector3 target)
    {
        if (Vector3.Distance(agent, target) >= threshholdDistance)
        {
            return false;
        }
        return true;
    }
}
