using UnityEngine;
using UnityEngine.UIElements;

public class TopMenu : MonoBehaviour
{
    public Label waveLabel;
    public Label creditsLabel;
    public Label healthLabel;
    public Button startWaveButton;

    public void SetCreditsLabel(string text)
    {
        creditsLabel.text = text;
    }

    public void SetHealthLabel(string text)
    {
        healthLabel.text = text;
    }

    public void SetWaveLabel(string text)
    {
        waveLabel.text = text;
    }

    public void WaveButton_clicked()
    {
        // Roep de StartWave functie van GameManager aan
        GameManager.instance.StartWave();

        // Schakel de waveButton uit
        startWaveButton.SetEnabled(false);
    }

    public void EnableWaveButton()
    {
        // Schakel de waveButton weer in
        startWaveButton.SetEnabled(true);
    }
}
