using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Option : MonoBehaviour
{
    [SerializeField]
    private string _playerTag = "Player";

    public string _sceneName = "SceneNameHere";


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _playerTag)
        {
            StoryManager.Instance.MoveStory(this);
            Destroy(this.gameObject);
        }
    }
}
