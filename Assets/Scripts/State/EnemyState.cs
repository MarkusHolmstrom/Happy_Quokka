using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    public enum State { Idle, Chasing };
    public State CurrentState { get; set; }
}
