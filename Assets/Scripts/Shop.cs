using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseGuitarTower()
    {
        Debug.Log("guitar tower");
        buildManager.SetTowerToBuild(buildManager.GuitarTower);
    }
    
    public void PurchaseDrummerTower()
    {
        Debug.Log("drummer tower");
        buildManager.SetTowerToBuild(buildManager.DrummerTower);
    }

    public void PurchaseKeyboardTower()
    {
        Debug.Log("keyboard tower");
        buildManager.SetTowerToBuild(buildManager.KeyboardTower);
    }

    public void PurchaseDjTower()
    {
        Debug.Log("dj tower");
        buildManager.SetTowerToBuild(buildManager.DjTower);
    }
}
