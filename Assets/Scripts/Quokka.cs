using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://craftgames.co/unity-2d-platformer-movement/

public class Quokka : MonoBehaviour
{
    [SerializeField]
    private GameObject _katana;
    [SerializeField]
    private GameObject _chainsaw;

    public GameObject curWeapon { get; private set; }

    private Vector3 _startKatanaPosition;
    private readonly Vector3 _altKatanaPosition = new Vector3(-0.38f, -0.34f, 0.5f);
    private Vector3 _startChainSawPosition;
    private readonly Vector3 _altChainsawPosition = new Vector3(0.475f, -0.53f, 0.518f);

    private List<GameObject> _weapons = new List<GameObject>();

    [SerializeField]
    private float _moveSpeed = 2f;
    private float _health = 10.0f;

    [SerializeField]
    private float _jumpForce = 5f;
    private float _fallMultiplier = 2.5f;
    private float _lowJumpMultiplier = 2f;

    private Rigidbody2D _rb;

    private bool _isGrounded = false;
    [SerializeField] 
    private Transform _groundedChecker;
    [SerializeField] 
    private float _checkGroundRadius;
    [SerializeField] 
    private LayerMask _groundLayer;

    private float _rememberGroundedFor = 0.1f;
    private float _lastTimeGrounded;

    private int _defaultAdditionalJumps = 1;
    private int _additionalJump;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _weapons.Add(_katana);
        _weapons.Add(_chainsaw);
        _startChainSawPosition = _chainsaw.transform.localPosition;
        _startKatanaPosition = _katana.transform.localPosition;
        curWeapon = ChangeWeapon(_chainsaw);
        // Quokka must be alive during scene changes, no?
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
        ChangeDirection();
        if (curWeapon != _chainsaw && Input.GetKey(KeyCode.C))
        {
            StateManager.Instance.ChangeCurrentWeapon(State.Weapon.Chainsaw);
            curWeapon = ChangeWeapon(_chainsaw);
        }
        else if (curWeapon != _katana && Input.GetKey(KeyCode.K))
        {
            StateManager.Instance.ChangeCurrentWeapon(State.Weapon.Katana);
            curWeapon = ChangeWeapon(_katana);
        }
    }

    private float _movement = 0;

    private void Move()
    {
        _movement = Input.GetAxisRaw("Horizontal");
        float moveBy = _movement * _moveSpeed;
        _rb.velocity = new Vector2(moveBy, _rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && 
            (_isGrounded || Time.time - _lastTimeGrounded <= _rememberGroundedFor || _additionalJump > 0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _additionalJump--;
        }
    }

    private void BetterJump()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rb.velocity += Vector2.up * Physics2D.gravity * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(_groundedChecker.position, _checkGroundRadius, _groundLayer);
        if (colliders != null)
        {
            _isGrounded = true;
            _additionalJump = _defaultAdditionalJumps;
        }
        else
        {
            if (_isGrounded)
            {
                _lastTimeGrounded = Time.time;
            }
            _isGrounded = false;
        }
    }

    private GameObject ChangeWeapon(GameObject weapon) 
    {
        foreach (GameObject w in _weapons)
        {
            if (weapon.name == w.name)
            {
                w.SetActive(true);
            }
            else
            {
                w.SetActive(false);
            }
        }
        return weapon;
    }

    private const float katanaZAngle = 5.306f; // Precision is key regarding katanas...

    public void ChangeDirection()
    {
        if (_movement > 0)
        {
            _katana.transform.localPosition = _startKatanaPosition;
            _katana.transform.localEulerAngles = new Vector3(180, 180, katanaZAngle);

            _chainsaw.transform.localPosition = _startChainSawPosition;
            _chainsaw.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if (_movement < 0)
        {
            _katana.transform.localPosition = _altKatanaPosition;
            _katana.transform.localEulerAngles = new Vector3(180, 0, katanaZAngle);

            _chainsaw.transform.localPosition = _altChainsawPosition;
            _chainsaw.transform.localEulerAngles = new Vector3(180, 0, 0);
        }
    }



    public float InjureQuokka(float damage)
    {
        _health -= damage;
        StateManager.Instance.RemoveLife(damage);
        return _health;
    }
}
