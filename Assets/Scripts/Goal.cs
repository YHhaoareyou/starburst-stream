using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject destroyEffectParticle;
    public GameObject dragonSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dragon"))
        {
            //Debug.Log("Gameover");

            // Play destroy effect
            GameObject destroyEffect = Instantiate(destroyEffectParticle, transform.position, Quaternion.identity);
            Destroy(destroyEffect, 5);

            // Destroy dragons
            GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");
            for (var i = 0; i < dragons.Length; i++)
                Destroy(dragons[i]);
            //Destroy(other.gameObject);

            // Destroy dragon spawner
            Destroy(dragonSpawner);

            // Destroy goal itself
            Destroy(gameObject);
        }
    }
}
