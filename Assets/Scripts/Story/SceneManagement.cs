using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string[] sceneNames = new string[3];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadANewScene(int index)
    {
        if (sceneNames.Length < index && sceneNames[index] != null)
        {
            SceneManager.LoadScene(sceneNames[index]);
        }
        else
        {
            Debug.LogError("Error: scene not found with index: " + index);
        }
    }

    public void LoadANewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
