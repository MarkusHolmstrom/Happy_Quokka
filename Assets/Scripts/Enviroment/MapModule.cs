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
        private Transform _enemySpawnPosition;


        public void DeActivateBorder(int index)
        {
            _borders[index].SetActive(false);
        }

        public Transform GetSpawnTransform()
        {
            return _enemySpawnPosition;
        }
    }
}
    
