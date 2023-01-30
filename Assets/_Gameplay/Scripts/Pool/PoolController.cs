using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public Transform brickHolder;
    public GameObject brickPrefab;

    public Transform stackHolder;
    public Stack stackPrefab;

    public GameObject stepPrefab;
    public Transform stepHolder;

    public int numOfStepsPerBridge;
    public int numOfBridge;

    private void Awake()
    {
        SimplePool.PreLoad(brickPrefab, 72, brickHolder);

        SimplePool.PreLoad(stackPrefab.gameObject, 40, stackHolder);

        SimplePool.PreLoad(stepPrefab, numOfStepsPerBridge * numOfBridge, stepHolder);
    }

}
