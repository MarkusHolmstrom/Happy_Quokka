using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviroment;
using Factory; // From GameFactory class

// This is only used in scenes 100, 010 and 001
// Creates a moduled map and adds enemies via the factory

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject _modulePrefab;
    [SerializeField]
    private GameObject _seesawPrefab;
    [SerializeField]
    private GameObject _spinOpstaclePrefab;

    [SerializeField]
    private GameObject _enemyPrefab;
    [Range(0, 4)]
    [SerializeField]
    private int _nrOfEnemiesPerScene = 3;

    private List<MapModule> _mapModules = new List<MapModule>();
    private float _xPosition = 0, _yPosition = 0;
    private int _cornerIndex = 1;

    private int _obstacleIndex;

    GameFactory gameFactory = new GameFactory();

    // Start is called before the first frame update
    void Start()
    {
        LoadNewLevel(5, 3, 15);
        GenerateEnemies(_nrOfEnemiesPerScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadNewLevel(int rows, int columns, int numberOfModules)
    {
        _obstacleIndex = 0;
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
        GameObject mod = Instantiate(_modulePrefab, new Vector3(_xPosition, _yPosition, 0), Quaternion.identity);
        MapModule module = mod.GetComponent<MapModule>();
        if (_obstacleIndex == 0)
        {
            GameObject seesaw = Instantiate(_seesawPrefab, mod.transform);
            seesaw.transform.localPosition = Vector3.zero;
            _obstacleIndex++;
        }
        else
        {
            GameObject spin = Instantiate(_spinOpstaclePrefab, mod.transform);
            spin.transform.localPosition = Vector3.zero;
            _obstacleIndex = 0;
        }

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

    private void GenerateEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            gameFactory.CreateItem(IGameFactory.Item.Enemy, SetUpEnemy(i));
        }
    }
    /// <summary>
    /// Instantiates an enemy and set its position based on the map modules created
    /// with it set as its parent, to later remove it so they are not depended on the 
    /// map module. 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private GameObject SetUpEnemy(int index)
    {
        index++; // Keeps the first module free from enemies, room for player to land
        GameObject enemy = Instantiate(_enemyPrefab, _mapModules[index].gameObject.transform);
        enemy.transform.position = _mapModules[index].GetSpawnTransform().position;
        enemy.transform.SetParent(null);
        return enemy;
    }
}
