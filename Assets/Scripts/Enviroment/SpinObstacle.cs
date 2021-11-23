using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment
{
    public class SpinObstacle : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] arms = new GameObject[2];

        [SerializeField]
        private float _rotateSpeed = 6.0f;
        private float _angleZ = 0;
        private int _rotateDirection = 1;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Rotate along the z-axis:
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _angleZ += _rotateSpeed * Time.deltaTime * _rotateDirection);
        }

        public void RemoveOneArm()
        {
            arms[1].SetActive(false);
        }

        public void ChangeRotateSpeed(float newSpeed)
        {
            _rotateSpeed = newSpeed;
        }

        public void ChangeRotationDirection()
        {
            _rotateDirection = -1;
        }
    }
}

