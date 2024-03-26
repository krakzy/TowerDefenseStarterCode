using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text gameEndMessageText;
    public Text winLossLabelText;
    public Text highScoresLabelText;
    public Text[] highScoreLabels;
    public Button newGameButton;

    void Start()
    {
        newGameButton.onClick.AddListener(StartNewGame);
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update game end message
        gameEndMessageText.text = GameManager.instance.GameIsWon ? "Congratulations! You won!" : "Game over! You lost.";

        // Update win/loss label
        winLossLabelText.text = GameManager.instance.GameIsWon ? "You Won!" : "You Lost!";

        // Update high scores labels
        // For demonstration purposes, assuming high scores are stored in GameManager
        for (int i = 0; i < GameManager.instance.HighScores.Length; i++)
        {
            highScoreLabels[i].text = GameManager.instance.HighScores[i].ToString();
        }
    }

    void StartNewGame()
    {
        GameManager.instance.StartGame();
        // Load the GameScene
        SceneManager.LoadScene("GameScene");
    }
}
