using UnityEngine;
using UnityEngine.UIElements;
using Enums;

public class TowerMenu : MonoBehaviour
{
    public static TowerMenu instance;

    private Button archerButton;
    private Button swordButton;
    private Button wizardButton;
    private Button upgradeButton;
    private Button destroyButton;

    private VisualElement root;

    private ConstructionSite selectedSite;

    public void SelectSite(ConstructionSite site)
    {
        GameManager.instance.SelectSite(site);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        archerButton = root.Q<Button>("archerbutton");
        swordButton = root.Q<Button>("swordbutton");
        wizardButton = root.Q<Button>("wizardbutton");
        upgradeButton = root.Q<Button>("upgradebutton");
        destroyButton = root.Q<Button>("deletebutton");

        if (archerButton != null)
        {
            archerButton.clicked += OnArcherButtonClicked;
        }

        if (swordButton != null)
        {
            swordButton.clicked += OnSwordButtonClicked;
        }

        if (wizardButton != null)
        {
            wizardButton.clicked += OnWizardButtonClicked;
        }

        if (upgradeButton != null)
        {
            upgradeButton.clicked += OnUpdateButtonClicked;
        }

        if (destroyButton != null)
        {
            destroyButton.clicked += OnDestroyButtonClicked;
        }

        root.visible = false;
    }

    public void ToggleVisibility()
    {
        root.visible = !root.visible;
    }

    public void SetSite(ConstructionSite site)
    {
        selectedSite = site;
        root.visible = selectedSite != null;

        EvaluateMenu();
    }

    private void EvaluateMenu()
    {
        if (selectedSite == null)
            return;

        // Check site level
        int siteLevel = (int)selectedSite.Level;

        switch (siteLevel)
        {
            case 0:
                upgradeButton.SetEnabled(false);
                destroyButton.SetEnabled(false);
                break;
            case 1:
            case 2:
                archerButton.SetEnabled(false);
                wizardButton.SetEnabled(false);
                swordButton.SetEnabled(false);
                destroyButton.SetEnabled(true);
                break;
            case 3:
                archerButton.SetEnabled(false);
                wizardButton.SetEnabled(false);
                swordButton.SetEnabled(false);
                upgradeButton.SetEnabled(false);
                destroyButton.SetEnabled(true);
                break;
            default:
                Debug.LogError("Unknown site level: " + siteLevel);
                break;
        }
    }

    private void OnArcherButtonClicked()
    {
        // Handle archer button click
    }

    private void OnSwordButtonClicked()
    {
        // Handle sword button click
    }

    private void OnWizardButtonClicked()
    {
        // Handle wizard button click
    }

    private void OnUpdateButtonClicked()
    {
        // Handle update button click
    }

    private void OnDestroyButtonClicked()
    {
        // Handle destroy button click
    }

    private void OnDestroy()
    {
        if (archerButton != null)
        {
            archerButton.clicked -= OnArcherButtonClicked;
        }

        if (swordButton != null)
        {
            swordButton.clicked -= OnSwordButtonClicked;
        }

        if (wizardButton != null)
        {
            wizardButton.clicked -= OnWizardButtonClicked;
        }

        if (upgradeButton != null)
        {
            upgradeButton.clicked -= OnUpdateButtonClicked;
        }

        if (destroyButton != null)
        {
            destroyButton.clicked -= OnDestroyButtonClicked;
        }
    }
}
