// using UnityEngine;

// public class GrenadeThrower : MonoBehaviour
// {
//     [SerializeField] private float throwForce = 40f;
//     [SerializeField] private GameObject grenadePrefab;

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             ThrowGrenade();
//         }
//     }

//     private void ThrowGrenade()
//     {
//         GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
//         Rigidbody rb = grenade.GetComponent<Rigidbody>();
//         if (rb != null)
//         {
//             rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
//         }
//     }
// }

using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private float throwForce = 40f;
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform throwPoint; // Reference to the hand or weapon position
    [SerializeField] private float grenadeCooldown = 2f;

    private float nextThrowTime = 0f;

    void Update()
    {
        // Throw grenade on left-click
        if (Input.GetMouseButtonDown(0) && Time.time >= nextThrowTime)
        {
            nextThrowTime = Time.time + grenadeCooldown;
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        // Instantiate grenade prefab at the throw point
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);

        // Add force to throw the grenade
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}
