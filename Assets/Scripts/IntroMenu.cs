using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class IntroMenu : MonoBehaviour
{
    private Button startButton;
    private Button quitButton;
    private TextField textField;

    void Start()
    {
        // Zoek de start button en voeg een click event listener toe
        startButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("startButton");
        startButton.clickable.clicked += StartGame;

        // Zoek de quit button en voeg een click event listener toe
        quitButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("quitButton");
        quitButton.clickable.clicked += QuitGame;

        // Zoek het textField
        textField = GetComponent<UIDocument>().rootVisualElement.Q<TextField>("textField");

        // Start button is disabled wanneer het menu opent
        startButton.SetEnabled(false);

    }

    void OnDestroy()
    {
        // Verwijder event listeners om geheugenlekken te voorkomen
        startButton.clickable.clicked -= StartGame;
        quitButton.clickable.clicked -= QuitGame;
    }

    void StartGame()
    {
        // Laad de GameScene
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
        // Sluit de applicatie af
        Application.Quit();
    }
}
