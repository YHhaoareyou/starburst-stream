using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public List<GameObject> dragons = new List<GameObject>(3);
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnDragon", 10, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnDragon()
    {
        int dragonIdx = Random.Range(0, 3);
        Vector3 spawnPosition = (goal.transform.position + Random.onUnitSphere) * 30;
        Instantiate(dragons[dragonIdx], spawnPosition, Quaternion.LookRotation(goal.transform.position - spawnPosition));
    }
}
