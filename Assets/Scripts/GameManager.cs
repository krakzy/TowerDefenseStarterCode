using UnityEngine;
using System.Collections.Generic;
using Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> Archers;
    public List<GameObject> Swords;
    public List<GameObject> Wizards;

    private int credits;
    private int health;
    private int currentWave;

    private ConstructionSite selectedSite;

    // Reference to the menu
    public GameObject menu;
    public GameObject TopMenu;


    public TopMenu topMenu;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        // Initialiseer waarden
        credits = 200;
        health = 10;
        currentWave = 0;

        // Update de labels in het TopMenu
        UpdateLabels();
    }

    void UpdateLabels()
    {
        // Stel de tekst in voor elk label in het TopMenu
        topMenu.SetCreditsLabel("Credits: " + credits);
        topMenu.SetHealthLabel("Gate Health: " + health);
        topMenu.SetWaveLabel("Wave: " + currentWave);
    }

    public void AttackGate()
    {
        // Verminder de gezondheid van de poort met 1
        health -= 1;

        // Update de label in het TopMenu
        topMenu.SetHealthLabel("Gate Health: " + health);
    }

    public void AddCredits(int amount)
    {
        // Voeg credits toe
        credits += amount;

        // Update de labels in het TopMenu
        UpdateLabels();

        // Evalueer het torenmenu
        // Dit doet voor nu niets, maar later voegen we code toe om credits te controleren
    }

    public void RemoveCredits(int amount)
    {
        // Verminder credits
        credits -= amount;

        // Update de labels in het TopMenu
        UpdateLabels();
    }

    public int GetCredits()
    {
        // Geeft het aantal credits terug
        return credits;
    }

    public int GetCost(TowerType type, SiteLevel level, bool selling = false)
    {
        // Geef de kosten terug voor elk type toren
        // De terugkeer moet lager zijn als je verkoopt

        int cost = 0;

        // Voeg hier logica toe om de kosten te berekenen op basis van het torentype, het niveau en of het wordt verkocht

        return cost;
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

    // Method to open the menu when a site is selected
    public void OpenMenu()
    {
        menu.SetActive(true); // Set the menu to active
        // You can add further logic here to customize or populate the menu based on the selected site
    }

    public void SelectSite(ConstructionSite site)
    {
        selectedSite = site;
        // Open the menu when a site is selected
        //OpenMenu();

        // Here you obtain a reference to TowerMenu via GetComponent
        TowerMenu towerMenu = menu.GetComponent<TowerMenu>();
        if (towerMenu != null)
        {
            towerMenu.SetSite(selectedSite);
        }
    }

    public void Build(TowerType type, SiteLevel level)
    {
        // Check if a site is selected
        if (selectedSite == null)
        {
            Debug.LogWarning("Er is geen site geselecteerd om te bouwen");
            return;
        }

        // Select the correct list of prefab towers based on the tower type
        List<GameObject> towerList = null;
        switch (type)
        {
            case TowerType.Archer:
                towerList = Archers;
                break;
            case TowerType.Sword:
                towerList = Swords;
                break;
            case TowerType.Wizard:
                towerList = Wizards;
                break;
            default:
                Debug.LogError("Ongeldig torentype: " + type);
                return;
        }

        // Check if the list of prefab towers is assigned
        if (towerList == null || towerList.Count == 0)
        {
            Debug.LogError("Er zijn geen prefab torens beschikbaar voor het opgegeven type: " + type);
            return;
        }

        // Check if the specified level is within the range of the prefab tower list
        if ((int)level < 0 || (int)level >= towerList.Count)
        {
            Debug.LogError("Ongeldig niveau voor het opgegeven torentype: " + level);
            return;
        }

        // Check if the site level indicates selling (level 0) or purchasing (higher levels)
        if (level == SiteLevel.level0) // Verkoop
        {
            // Bereken de kosten voor het verkopen van de toren
            int cost = GetCost(type, level, true);

            // Voeg credits toe
            AddCredits(cost);
        }
        else // Aankoop
        {
            // Bereken de kosten voor het kopen van de toren
            int cost = GetCost(type, level);

            // Controleer of de speler voldoende credits heeft
            if (cost <= GetCredits())
            {
                // Verwijder de kosten van de credits
                RemoveCredits(cost);

                // Bouw de toren
                GameObject towerPrefab = towerList[(int)level];
                if (towerPrefab != null)
                {
                    GameObject newTower = Instantiate(towerPrefab, selectedSite.WorldPosition, Quaternion.identity);
                    selectedSite.SetTower(newTower, level, type);
                }
                else
                {
                    Debug.LogError("Prefab toren op niveau: " + level + " is niet toegewezen");
                }
            }
            else
            {
                Debug.LogWarning("Onvoldoende credits om de toren te bouwen");
            }
        }

        // Verberg het menu door null door te geven aan de SetSite-functie in TowerMenu
        menu.GetComponent<TowerMenu>().SetSite(null);
    }

}

