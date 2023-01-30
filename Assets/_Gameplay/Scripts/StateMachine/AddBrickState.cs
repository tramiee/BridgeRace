using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBrickState : IState
{
    float timer = 0;
    float randomTime;
    public void OnEnter(Enemy enemy)
    {
        enemy.Move();
        timer = 0;
        randomTime = Random.Range(5f, 7f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if(timer > randomTime)
        {
            enemy.ChangeState(new BuildBridgeState());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }
}
