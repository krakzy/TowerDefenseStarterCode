using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> Archers;
    public List<GameObject> Swords;
    public List<GameObject> Wizards;

    private ConstructionSite selectedSite;

    // Reference to the menu
    public GameObject menu;

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

    public void Build(Enums.TowerType type, Enums.SiteLevel Level)
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
            case Enums.TowerType.Archer:
                towerList = Archers;
                break;
            case Enums.TowerType.Sword:
                towerList = Swords;
                break;
            case Enums.TowerType.Wizard:
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
        if ((int)Level < 0 || (int)Level >= towerList.Count)
        {
            Debug.LogError("Ongeldig niveau voor het opgegeven torentype: " + Level);
            return;
        }

        // Create a tower from the list of prefab towers based on the specified level
        GameObject towerPrefab = towerList[(int)Level];
        if (towerPrefab == null)
        {
            Debug.LogError("Prefab toren op niveau: " + Level + " is niet toegewezen");
            return;
        }

        // Place the tower on the selected site
        GameObject newTower = Instantiate(towerPrefab, selectedSite.WorldPosition, Quaternion.identity);
        // Pass the TowerType parameter to SetTower method
        selectedSite.SetTower(newTower, Level, type);

        // Hide the menu by passing null to the SetSite function in TowerMenu
        menu.GetComponent<TowerMenu>().SetSite(null);
    }
}

