using UnityEngine;
using Enums;

public class ConstructionSite
{
    public Vector3Int TilePosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public Enums.Path Level { get; private set; }  
    public Enums.TowerType? TowerType { get; private set; }  

    private GameObject tower;

    public ConstructionSite(Vector3Int tilePosition, Vector3 worldPosition)
    {
        TilePosition = tilePosition;
        // Adjust the world position
        WorldPosition = new Vector3(worldPosition.x, worldPosition.y + 0.5f, worldPosition.z);
        TowerType = null;
    }

    public void SetTower(GameObject newTower, Enums.Path newLevel, Enums.TowerType newType)
    {
        // Check if there is already a tower
        if (tower != null)
        {
            // Destroy the existing tower before assigning the new one
            GameObject.Destroy(tower);
        }

        // Assign the new tower and properties
        tower = newTower;
        Level = newLevel;
        TowerType = newType;
    }
}
