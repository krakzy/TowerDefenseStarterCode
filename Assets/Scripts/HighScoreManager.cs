using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    // Public properties
    public string PlayerName { get; set; }
    public bool GameIsWon { get; set; }

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensures that the gameObject is not destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Ensures that only one instance of the HighScoreManager exists
        }
    }

    // Add other methods related to high score management here...
}

