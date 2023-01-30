using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public int numx;
    public int numz;
    public float space;
    public Transform brickSpawner;
    public Brick brickPrefab;
    public List<ColorType> colorTypes;
    public List<Vector3> allBrickPoses = new List<Vector3>();
    public int numEachBrickType;
    void Start()
    {
        SpawnerBrick();
    }

    private void SpawnerBrick()
    {
        for (int i = 0; i < numx; i++)
        {
            for (int j = 0; j < numz; j++)
            {
                allBrickPoses.Add(brickSpawner.position + new Vector3(i * space, 0.08f, j * space));
            }
        }

        for (int i = 0; i < numEachBrickType; i++)
        {
            for (int j = 0; j < colorTypes.Count; j++)
            {
                Vector3 randomPos = allBrickPoses[Random.Range(0, allBrickPoses.Count)];
                allBrickPoses.Remove(randomPos);
                //TODO: Fix pool
                GameObject newBrick = SimplePool.Spawn(brickPrefab.gameObject, randomPos, Quaternion.identity);
                Brick brick = newBrick.GetComponent<Brick>();
                brick.SetColor(colorTypes[j]);
            }
        }
    }
}
