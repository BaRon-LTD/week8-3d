// using System.Collections.Generic;
// using System.Collections;
// using UnityEngine;

// public class Granade : MonoBehaviour
// {
//     [SerializeField] private float delay = 3f;
//     [SerializeField] private GameObject explosionEffect;
//     [SerializeField] private float radius = 5f;
//     [SerializeField] private float force = 700f;

//     private float countdown;
//     private bool hasExploded = false;

//     // Start is called before the first execution of Update
//     void Start()
//     {
//         countdown = delay;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         countdown -= Time.deltaTime;
//         if (countdown <= 0 && !hasExploded)
//         {
//             Explode();
//             hasExploded = true;
//         }
//     }

//     private void Explode()
//     {
//         // Show explosion effect
//         Instantiate(explosionEffect, transform.position, transform.rotation);

//         // Get all colliders in the explosion radius
//         Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

//         // Apply force to nearby objects with a Rigidbody
//         foreach (Collider nearbyObject in colliders)
//         {
//             Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
//             if (rb != null)
//             {
//                 rb.AddExplosionForce(force, transform.position, radius);
//             }
//         }

//         // Remove the grenade from the scene after explosion
//         Destroy(gameObject);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float force = 700f;

    private float countdown;
    private bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (hasExploded) return;

        Debug.Log("Explode method called on: " + gameObject.name); // Debugging

        hasExploded = true;

        // Instantiate explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // OverlapSphere to find nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            // Skip the grenade itself
            if (nearbyObject.gameObject == gameObject) continue;

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        // Destroy the grenade after explosion
        Destroy(gameObject, 0.1f); // Slight delay for effect
    }
}
