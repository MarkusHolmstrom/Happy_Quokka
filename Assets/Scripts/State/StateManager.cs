using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


// This state managment is not necissary for the game, its basicly just to save game play progress
// and for me to get more experience how to use states. Can also be used to read for spefic in-game conditions,
// like if (state.CurrentWeapon == State.Weapon.Chainsaw) { DoBloodyMess() } etc

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private Text livesText;

    // Saves the states as a list, can be useful if the game option of visiting former scenes
    private LinkedList<State> states = new LinkedList<State>();

    // Singleton:
    private static StateManager _instance;
    public static StateManager Instance { get { return _instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            SetupFirstState();
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

    private void SetupFirstState()
    {
        // Starting settings:
        State state = new State
        {
            Lives = 3f,
            Score = 0,
            CurrentScene = SceneManager.GetActiveScene()
        };
        AddNewState(state);
    }
    /// <summary>
    /// Gets called every time a new scene opens
    /// </summary>
    /// <param name="state"></param>
    public void AddNewState(State state)
    {
        states.AddLast(state);
    }

    /// <summary>
    /// Only updates current state and health when Quokka gets injured
    /// Also checks if Quokka have any lives remaining
    /// </summary>
    /// <param name="damage"></param>
    public void RemoveLife(float damage) 
    {
        states.Last.Value.Lives -= damage;
        if (states.Last.Value.Lives > 0)
        {
            CalculateLivesText(states.Last.Value.Lives);
        }
        else
        {
            livesText.text = "Dead as a dodo!";
            Debug.Log("Game over!!");
        }
    }

    private void CalculateLivesText(float livesRem)
    {
        string text = "";
        bool even = true; // Ugly solution to get the right char
        for (float i = 0; i < livesRem; i += 0.5f)
        {
            if (even)
            {
                text += "<";
                even = false;
            }
            else 
            {
                text += "3 ";
                even = true;
            }
        }
        livesText.text = text;
    }

    public void AddScore(int newScore) 
    {
        states.Last.Value.Score += newScore;
    }
    // Important distinction from the class Weapon, this is only enum from the State class
    public State.Weapon ChangeCurrentWeapon(State.Weapon weapon)
    {
        states.Last.Value.CurrentWeapon = weapon;
        return weapon;
    }
}
