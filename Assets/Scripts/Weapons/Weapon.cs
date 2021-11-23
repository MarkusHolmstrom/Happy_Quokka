using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public interface IWeapon
    {
        float damage { get; set; }
        float DoDamage(float damage);
        bool isCurrentWeapon { get; set; }
    }
}
