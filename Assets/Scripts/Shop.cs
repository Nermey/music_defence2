using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint guitarTower;
    public TowerBlueprint drummerTower;
    public TowerBlueprint keyboardTower;
    public TowerBlueprint djTower;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectGuitarTower()
    {
        Debug.Log("guitar tower");
        buildManager.SelectTowerToBuild(guitarTower);
    }
    
    public void SelectDrummerTower()
    {
        Debug.Log("drummer tower");
        buildManager.SelectTowerToBuild(drummerTower);
    }

    public void SelectKeyboardTower()
    {
        Debug.Log("keyboard tower");
        buildManager.SelectTowerToBuild(keyboardTower);
    }

    public void SelectDjTower()
    {
        Debug.Log("dj tower");
        buildManager.SelectTowerToBuild(djTower);
    }
}
