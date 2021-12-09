using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Option : MonoBehaviour
{
    [SerializeField]
    private string _playerTag = "Player";

    public string _sceneName = "SceneNameHere";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _playerTag)
        {
            StoryManager.Instance.MoveStory(this);
            Destroy(this.gameObject);
        }
    }
}
