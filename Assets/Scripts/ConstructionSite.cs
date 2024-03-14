using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionSite
{
    public enum SiteLevel
    {
    Onbebouwd,
    Level1,
    Level2,
    Level3
    }
    
    public Vector3Int TilePosition { get; set; }

    public Vector3 WorldPosition { get; set; }

    public SiteLevel Level { get; set; }

    public TowerType TowerType { get; set; }

    private GameObject tower {get; set;}

    public ConstructionSite(Vector3Int tilePosition, Vector3 worldPosition)
    {
        TilePosition = tilePosition;
        
        WorldPosition = new Vector3(worldPosition.x, worldPosition.y + 0.5f, worldPosition.z);
        
        tower = null;
    }

        public void SetTower(GameObject newTower, SiteLevel level, TowerType type)
    {
        if (tower != null)
        {
            GameObject.Destroy(tower);
        }
        
        tower = newTower;
        Level = level;
        TowerType = type;
    }
}
