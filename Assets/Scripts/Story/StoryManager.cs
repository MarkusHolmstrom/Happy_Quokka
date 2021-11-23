using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    // Singleton:
    private static StoryManager _instance;
    public static StoryManager Instance { get { return _instance; } }

    // 

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

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
        return Vector3Int.zero;
    }
}
