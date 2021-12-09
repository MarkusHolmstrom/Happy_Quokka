using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private Vector3[] _positions;

    private float _offsetDistance = 4.0f;

    private int _index;
    // Only used for the enemies:
    private bool _chasingPlayer = false;

    void Awake()
    {
        if (_positions.Length == 0 || (_positions.Length == 2 && _positions[0] == _positions[1]))
        {
            _positions = SetTargetPositions();
        }
    }

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

    private Vector3[] SetTargetPositions()
    {
        Vector3[] v3s = new Vector3[2] { new Vector3(transform.position.x - _offsetDistance, 0, transform.position.z),
                                        new Vector3(transform.position.x + _offsetDistance, 0, transform.position.z),};
        return v3s;
    }

    /// <summary>
    /// Simple method so this GO chases the player
    /// </summary>
    /// <param name="player"></param>
    public void ChaseAfterPlayer(GameObject player)
    {
        _positions[_index] = player.transform.position;
        _chasingPlayer = true;
    }
}
