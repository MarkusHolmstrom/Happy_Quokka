using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject _qoukka;

    private float zoom = 0;
    private float maxClamp = 0.5f;
    private float rotSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        _qoukka = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_qoukka.transform.position.x, _qoukka.transform.position.y, transform.position.z + Zoom());
        
    }

    private float Zoom()
    {
        zoom += Input.GetAxis("Mouse ScrollWheel");
        zoom = Mathf.Clamp(zoom, -maxClamp, maxClamp);
        float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), maxClamp - Mathf.Abs(zoom));
        return translate * rotSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel"));
    }

}
