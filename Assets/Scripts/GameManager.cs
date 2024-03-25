using UnityEngine;
using System.Collections.Generic;
using Enums;

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
        // OpenMenu();

        // Here you obtain a reference to TowerMenu via GetComponent
        TowerMenu towerMenu = menu.GetComponent<TowerMenu>();
        if (towerMenu != null)
        {
            towerMenu.SetSite(selectedSite);
        }
    }
}

