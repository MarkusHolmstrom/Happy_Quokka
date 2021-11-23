using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Option : MonoBehaviour
{
    StoryManager sm;

    // Start is called before the first frame update
    void Awake()
    {
        sm = StoryManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sm.MoveStory(this);
            Destroy(this.gameObject);
        }
    }
}
