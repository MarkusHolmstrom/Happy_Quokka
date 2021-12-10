using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scenes information:
// StartScene = a startscene
// 100, 001 and 010 are next, depending on which option the player chooses in startscene
// The island beach scenes are last and pretty much empty, just beatiful views and deadends

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

    // Called from class "Option", when it gets activated by player
    public void MoveStory(Option opt)
    {
        SceneManager.LoadScene(opt._sceneName);
        _quokka.transform.position = _startPositionInNewScene;
    }
}
