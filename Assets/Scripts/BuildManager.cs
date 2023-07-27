using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject GuitarTower;
    public GameObject DrummerTower;
    public GameObject KeyboardTower;
    public GameObject DjTower;

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


    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }


    public GameObject GetTowerToBuild () 
    { 
        return towerToBuild;
    }   
}
