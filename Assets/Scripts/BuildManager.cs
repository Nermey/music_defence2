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

    public void BuildTowerOn(Stage stage)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Копи бичара :)");
            return;
        }

        PlayerStats.Money -= towerToBuild.cost;
        GameObject tower = (GameObject) Instantiate(towerToBuild.prefab, stage.GetBuildPosition(), Quaternion.identity);
        stage.tower = tower;

        Debug.Log("tower is builded! Money: " + PlayerStats.Money);
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
}
