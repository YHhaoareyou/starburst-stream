using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public List<GameObject> dragons = new List<GameObject>(3);
    public GameObject goal;

    public static float level;
    public static string mode;

    private float levelUpInterval;
    private float spawnInterval;
    private float spawnIntervalOffset;

    // Start is called before the first frame update
    void Start()
    {
        levelUpInterval = 40;
        spawnInterval = 5;
        level = 0;
        mode = "hard";
        spawnIntervalOffset = (mode == "hard") ? 5.5f : 7;
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0)
        {
            SpawnDragon();
            spawnInterval = spawnIntervalOffset - level / 2;

        }

        if (level < 9) levelUpInterval -= Time.deltaTime;
        if (levelUpInterval < 0)
        {
            level++;
            levelUpInterval = 30;
            Debug.Log("Level Up: " + level);
        }
        
    }

    void SpawnDragon()
    {
        int dragonIdx = Random.Range(0, 3);
        Vector3 spawnPosition = (goal.transform.position + UpperFrontSpherePos()) * 30;
        Instantiate(dragons[dragonIdx], spawnPosition, Quaternion.LookRotation(goal.transform.position - spawnPosition));
    }

    private Vector3 UpperFrontSpherePos()
    {
        Vector3 pos = Random.onUnitSphere;
        pos.y = Mathf.Abs(pos.y);
        pos.z = Mathf.Abs(pos.z);
        return pos;
    }
}
