using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour, Weapon.IWeapon
{
    public float damage { get; set; }
    public bool isCurrentWeapon { get; set; }

    public bool isActive = false;
    [SerializeField]
    private GameObject[] _chains = new GameObject[3];

    [SerializeField]
    private float _damage = 1.5f;

    private float _angleX = 90;
    private readonly float _rotatingChainSpeed = 5000f;
    private float _idleChainSpeed = 50f;
    private float _acceleration = 10f;

    public float DoDamage(float damage)
    {
        return damage;
    }

    // Start is called before the first frame update
    void Awake()
    {
        damage = _damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isActive)
        {
            StartCoroutine(StartRotation());
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopCoroutine(StartRotation());
            isActive = false;
        }
        if (isActive)
        {
            RotateChains(_rotatingChainSpeed);
        }
        else
        {
            RotateChains(_idleChainSpeed);
            _idleChainSpeed += _acceleration * Time.deltaTime;
        }
    }

    private IEnumerator StartRotation()
    {
        yield return new WaitForSeconds(2);
        isActive = true;
    }

    private void RotateChains(float speed)
    {
        _chains[0].transform.localEulerAngles = new Vector3(_angleX += Time.deltaTime * speed, 90, 90);
        _chains[1].transform.localEulerAngles = new Vector3(_angleX += Time.deltaTime * speed, 90, 90);
        _chains[2].transform.localEulerAngles = new Vector3(_angleX += Time.deltaTime * speed, 90, 90);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.tag == "Enemy" && other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.GetInjured(DoDamage(damage));
        }
    }
}
