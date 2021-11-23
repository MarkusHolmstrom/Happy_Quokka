using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviroment;

public class MapCreator : MonoBehaviour
{
    public GameObject modulePrefab;
    public GameObject seesawPrefab;
    public GameObject spinOpstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadNewLevel(5, 3, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<MapModule> _mapModules = new List<MapModule>();
    private float _xPosition = 0, _yPosition = 0;
    private int _cornerIndex = 1;

    public void LoadNewLevel(int rows, int columns, int numberOfModules)
    {
        for (int i = 0; i < columns; i++)
        {
            _xPosition = 0;
            for (int j = 0; j < rows; j++)
            {
                if ((i == 0 && j == 0) || (i == 0 && j == rows - 1) || (i == columns - 1 && j == 0) || (i == columns - 1 && j == rows - 1))
                {
                    GetModuleCorner(_cornerIndex);
                    _cornerIndex++;
                }
                else if (j == 0)
                {
                    GetModuleCorner(5);
                }
                else if (j == rows - 1)
                {
                    GetModuleCorner(6);
                }
                else
                {
                    GetModuleCorner(0);
                }
                _xPosition += 20;
            }
            _yPosition -= 20;
        }
    }

    private GameObject GetModuleCorner(int cornerIndex)
    {
        GameObject mod = Instantiate(modulePrefab, new Vector3(_xPosition, _yPosition, 0), Quaternion.identity);
        MapModule module = mod.GetComponent<MapModule>();
        GameObject seesaw = Instantiate(seesawPrefab, mod.transform);
        seesaw.transform.localPosition = Vector3.zero;
        if (cornerIndex == 1)
        {
            module.DeActivateBorder(2);
            module.DeActivateBorder(3);
        }
        else if (cornerIndex == 2)
        {
            module.DeActivateBorder(1);
            module.DeActivateBorder(7);
        }
        else if (cornerIndex == 3)
        {
            module.DeActivateBorder(4);
            module.DeActivateBorder(2);
        }
        else if (cornerIndex == 4)
        {
            module.DeActivateBorder(7);
        }
        else if (cornerIndex == 5) // Along walls to the left:
        {
            module.DeActivateBorder(1);
            module.DeActivateBorder(2);
            module.DeActivateBorder(3);
            module.DeActivateBorder(4);
        }
        else if (cornerIndex == 6) // Along walls to the right:
        {
            module.DeActivateBorder(0);
            module.DeActivateBorder(4);
            module.DeActivateBorder(6);
            module.DeActivateBorder(7);
        }
        else // Middle modules with no walls:
        {
            module.DeActivateBorder(2);
            module.DeActivateBorder(3);
            module.DeActivateBorder(6);
            module.DeActivateBorder(7);
        }
        _mapModules.Add(module);
        return mod;
    }
}
