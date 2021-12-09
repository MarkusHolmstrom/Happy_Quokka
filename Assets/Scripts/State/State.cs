using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


// More of a player-based state

public class State 
{
    public float Lives { get; set; } // Lives remaining
    public int Score { get; set; } // Nr of kills
    public Scene CurrentScene { get; set; }

    public enum Weapon { Chainsaw, Katana}; 
    public Weapon CurrentWeapon { get; set; }

}
