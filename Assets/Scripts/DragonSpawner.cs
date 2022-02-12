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
        InvokeRepeating("SpawnDragon", 10, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
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
