using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weapon;
    public Transform origin;
    public void WeaponSpawn()
    {
        weapon.transform.position = origin.position;
        Instantiate(weapon);
    }
}
