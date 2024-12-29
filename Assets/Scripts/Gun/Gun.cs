using System;
using System.Numerics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private ParticleSystem muzzleFlash;
    // [SerializeField] private GameObject impactEffect;

    [SerializeField] Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
        
    }

    private void Shoot()
    {
       muzzleFlash.Play();
       RaycastHit hit;
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
       {
            Debug.Log(hit.transform.name);
            
            if( hit.transform.TryGetComponent<Target>(out var target))
            {
                target.TakeDamge(damage);
            }

            // Instantiate(impactEffect, hit.point, System.Numerics.Quaternion.CreateFromRotationMatrix(hit.normal));
       }
    }
}
