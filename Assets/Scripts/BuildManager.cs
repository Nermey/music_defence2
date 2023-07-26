using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standartTowerPrefab;

    private GameObject towerToBuild;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildManager!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        towerToBuild = standartTowerPrefab;
    }

    

    public GameObject GetTowerToBuild () 
    { 
        return towerToBuild;
    }   
}
