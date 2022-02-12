using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject destroyEffectParticle;
    public GameObject goal;
    private float speedOffset;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectsWithTag("Goal")[0];
        speedOffset = DragonSpawner.mode == "hard" ? 5 : 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.Normalize(goal.transform.position - transform.position);
        transform.position += moveDir * Time.deltaTime * (speedOffset + DragonSpawner.level);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            // Destroy effect
            GameObject destroyEffect = Instantiate(destroyEffectParticle, transform.position, Quaternion.identity);
            // Destroy the dragon
            Destroy(destroyEffect, 3);
            Destroy(gameObject);
        }
        //if (other.CompareTag("Barrier"))
        //{
        //    // Destroy the dragon
        //    Destroy(gameObject);
        //}
    }
}
