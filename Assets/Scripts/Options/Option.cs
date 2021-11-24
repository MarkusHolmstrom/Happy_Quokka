using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Option : MonoBehaviour
{
    public string playerTag = "Player";

    public string sceneName = "SceneNameHere";

    public StoryManager sm;

    // Start is called before the first frame update
    void Awake()
    {
        sm = StoryManager.Instance; // works only for the box, wwhy?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
            if (sm == null)
            {
                sm = StoryManager.Instance;
            }
            sm.MoveStory(this);
            Destroy(this.gameObject);
        }
    }
}
