using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject destroyEffectParticle;

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
        if (other.CompareTag("Sword"))
        {
            // Destroy effect
            Instantiate(destroyEffectParticle, transform.position, Quaternion.identity);
            // Destroy the dragon
            Destroy(gameObject);
        }
    }
}
