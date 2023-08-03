using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject GuitarTower;
    public GameObject DrummerTower;
    public GameObject KeyboardTower;
    public GameObject DjTower;

    private TowerBlueprint towerToBuild;
    private Stage selectedStage;

    public StageUI stageUI;

    public bool CanBuild 
    {
        get
        { 
            return towerToBuild != null; 
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= towerToBuild.cost;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildManager!");
            return;
        }
        instance = this;
    }

    public void SelectStage(Stage stage)
    {
        if (selectedStage == stage)
        {
            DeselectStage();
            return;
        }

        selectedStage = stage;
        towerToBuild = null;

        stageUI.SetTarget(stage);
    }

    public void DeselectStage()
    {
        selectedStage = null;
        stageUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;

        DeselectStage();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
