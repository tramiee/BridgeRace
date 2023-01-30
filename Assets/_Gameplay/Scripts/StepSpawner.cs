using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSpawner : MonoBehaviour
{
    public List<Transform> stepHolders;
    public Step stepPrefab;

    public int stepMax;
    public int stepIndex;

    // Start is called before the first frame update
    void Start()
    {
        SpawnerStep();
    }

    public void SpawnerStep()
    {
        while(stepIndex < stepMax)
        {
            for (int i = 0; i < stepHolders.Count; i++)
            {
                SimplePool.Spawn(stepPrefab.gameObject, stepHolders[i].position + new Vector3(0, 0.32f, 1f) * stepIndex, stepHolders[i].rotation);
            }
            stepIndex++;
        }
    }
}
