using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Located in Enviroment GO
// Only handles the background clouds:
// Object pooling is used so they are reused
public class CloudManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _clouds;


    [Range(0, 1f)]
    [SerializeField]
    private float _percentage = 0.5f;

    [Header("Should be beyond the end of the map")]
    [SerializeField]
    private float _xLimit = 500f;

    [Range(0.2f, 10f)]
    [SerializeField]
    private float _maxCloudSpeed = 3.5f;
    private List<float> _cloudSpeeds = new List<float>();

    private List<GameObject> _activeClouds = new List<GameObject>();

    private List<Vector3> _startPositions = new List<Vector3>();

    private bool _movingCloudsActive = true;

    // Start is called before the first frame update
    void Awake()
    {
        _startPositions = GetStartPositionsAndSetSpeeds();
        HideOrShowClouds(_clouds, false);
        _activeClouds = GetStartingClouds(_clouds, _percentage);
        HideOrShowClouds(_activeClouds, true);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_movingCloudsActive)
        {
            MoveClouds(_activeClouds);
        }
    }

    private List<Vector3> GetStartPositionsAndSetSpeeds()
    {
        List<Vector3> temp = new List<Vector3>();
        foreach (GameObject cloud in _clouds)
        {
            _cloudSpeeds.Add(Random.Range(0.1f, _maxCloudSpeed));
            // Save position for regenerating, fixing the x-pos so its offscreen:
            temp.Add(new Vector3(-_xLimit, cloud.transform.position.y, cloud.transform.position.z));
        }
        return temp;
    }

    private void HideOrShowClouds(IEnumerable<GameObject> clouds, bool show)
    {
        foreach (GameObject cloud in clouds)
        {
            cloud.SetActive(show);
        }
    }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="clouds"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    private List<GameObject> GetStartingClouds(GameObject[] clouds, float percentage)
    {
        List<GameObject> showingClouds = new List<GameObject>();
        float showingLength = clouds.Length * percentage; // create a float in case the arrays length isnt divisible evenly
        for (int i = 0; i < (int)showingLength; i++)
        {
            showingClouds.Add(clouds[i]);
        }
        return showingClouds;
    }


    private void MoveClouds(List<GameObject> clouds)
    {
        for (int i = 0; i < clouds.Count; i++)
        {
            clouds[i].transform.position = new Vector3(clouds[i].transform.position.x + Time.deltaTime * _cloudSpeeds[i],
                    clouds[i].transform.position.y, clouds[i].transform.position.z);
            if (clouds[i].transform.position.x > _xLimit)
            {
                ResetCloud(clouds[i], i);
            }
        }
    }

    private void ResetCloud(GameObject cloud, int index)
    {
        cloud.transform.position = _startPositions[index];
        cloud.SetActive(true);
    }
}
