using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private Vector3[] _positions;

    private int _index;
    // Only used for the enemies:
    private bool _chasingPlayer = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _positions[_index], Time.deltaTime * _speed);

        if (transform.position == _positions[_index] && !_chasingPlayer)
        {
            if (_index == _positions.Length - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }
        }
    }
    /// <summary>
    /// Simple method so the this GO chases the player
    /// </summary>
    /// <param name="player"></param>
    public void ChaseAfterPlayer(GameObject player)
    {
        _positions[_index] = player.transform.position;
        _chasingPlayer = true;
    }
}
