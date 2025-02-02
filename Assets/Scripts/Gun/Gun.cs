using System;
using System.Numerics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private ParticleSystem muzzleFlash;
    // [SerializeField] private GameObject impactEffect;

    [SerializeField] Camera fpsCam;

    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // Update next fire time
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

            if (hit.transform.TryGetComponent<Target>(out var target))
            {
                target.TakeDamge(damage);
            }

            // Instantiate(impactEffect, hit.point, System.Numerics.Quaternion.CreateFromRotationMatrix(hit.normal));
        }
    }
}
