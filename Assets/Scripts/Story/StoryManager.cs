using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneManagement))]
public class StoryManager : MonoBehaviour
{
    // Singleton:
    private static StoryManager _instance;
    public static StoryManager Instance { get { return _instance; } }

    // 
    private SceneManagement sceneManagement;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            sceneManagement = GetComponent<SceneManagement>();
            DontDestroyOnLoad(this.gameObject);

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

    // Called from Option, when it gets activated by player
    public Vector3Int MoveStory(Option opt)
    {
        Debug.Log("Quokka detected");
        sceneManagement.LoadANewScene(opt.sceneName);
        return Vector3Int.zero;
    }
}
