using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment
{
    public class MapModule : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _borders = new GameObject[8];

        [SerializeField]
        private GameObject[] _ledges = new GameObject[2];

        [SerializeField]
        private Transform _startPosition;

        public readonly Vector3 midPosition = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DeActivateBorder(int index)
        {
            _borders[index].SetActive(false);
        }
    }
}
    
