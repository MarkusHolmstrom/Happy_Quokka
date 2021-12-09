using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PingPong))]
public class Enemy : MonoBehaviour
{
    public EnemyState EnemyState { get; private set; }
    
    [SerializeField]
    private float _health = 5.0f;
    [SerializeField]
    private int _score = 1;
    [SerializeField]
    private float _damage = 0.5f;

    [Range(2, 50)]
    [SerializeField]
    private int _playerNoticeDistance = 5;
    [SerializeField]
    private string _playerTag = "Player";

    private Quokka _quokka;
    private GameObject _goQuokka;

    private PingPong _pingPong;

    // Start is called before the first frame update
    void Awake()
    {
        EnemyState = new EnemyState { CurrentState = EnemyState.State.Idle };
        _goQuokka = GameObject.FindGameObjectWithTag("Player");
        _quokka = _goQuokka.GetComponent<Quokka>();
        _pingPong = GetComponent<PingPong>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyState.CurrentState == EnemyState.State.Idle && CloseToPlayer(_playerNoticeDistance))
        {
            _pingPong.ChaseAfterPlayer(_goQuokka);
        }
    }

    private bool CloseToPlayer(int distance)
    {
        if (distance > Vector3.Distance(transform.position, _goQuokka.transform.position)) 
        {
            // Debug.Log("How bout a selfie, mate?");
            EnemyState.CurrentState = EnemyState.State.Chasing;
            return true;
        }
        return false;
    }

    public void GetInjured(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StateManager.Instance.AddScore(_score);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _playerTag)
        {
            _quokka.InjureQuokka(_damage);
        }
    }
}
