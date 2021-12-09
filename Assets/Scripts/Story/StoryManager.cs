using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    // Singleton:
    private static StoryManager _instance;
    public static StoryManager Instance { get { return _instance; } }

    [Header("Moves the player to this vector3 in the world map when loading a new scene:")]
    [SerializeField]
    private Vector3 _startPositionInNewScene = new Vector3(0, 4, 0);

    private GameObject _quokka;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            _quokka = GameObject.FindGameObjectWithTag("Player");
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called from class "Option", when it gets activated by player
    public Vector3Int MoveStory(Option opt)
    {
        _quokka.transform.position = _startPositionInNewScene;
        SceneManager.LoadScene(opt._sceneName);
        return Vector3Int.zero;
    }
}
