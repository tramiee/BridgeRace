using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridgeState : IState
{
    float timer = 0;
    float randomTime;
    public void OnEnter(Enemy enemy)
    {
        timer = 0;
        randomTime = Random.Range(5f, 6f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if(timer > randomTime)
        {
            enemy.ChangeState(new AddBrickState());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }
}
