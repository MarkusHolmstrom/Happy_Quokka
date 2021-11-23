using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour, Weapon.IWeapon
{
    public float damage { get; set; }
    public bool isCurrentWeapon { get; set; }

    public float DoDamage(float damage)
    {
        return damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
