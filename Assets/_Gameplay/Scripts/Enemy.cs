using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    NavMeshAgent agent;

    private IState currentState;

    public Brick brickPrefab;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        SetColor(ColorType.Red);
        agent = GetComponent<NavMeshAgent>();
        ChangeState(new AddBrickState());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState newState)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void Move()
    {
        ChangeAnim(Constant.ANIM_RUN);
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            targetPos = SimplePool.GetPositionBrick(brickPrefab.gameObject);
            agent.SetDestination(targetPos);
        }
    }

    public void StopMove()
    {
        ChangeAnim(Constant.ANIM_IDLE);
        agent.isStopped = true;
    }
    
}
