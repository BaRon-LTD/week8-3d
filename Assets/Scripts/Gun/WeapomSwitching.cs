using System;
using UnityEngine;

public class WeapomSwitching : MonoBehaviour
{
    [SerializeField] private int selectedWeapon = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectedWeapon();
        
    }

   

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;


        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount-1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
        
    }
    private void SelectedWeapon()
    {
        int i = 0;
       foreach (Transform weapon in transform)
       {
        if(i==selectedWeapon)
        {
            weapon.gameObject.SetActive(true);
        }
        else
        {
            weapon.gameObject.SetActive(false);

        }
            i++;
       }
    }
}
