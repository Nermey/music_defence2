using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Color hoverColor;
    public Color notMoneyColor;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    [Header("Optional")]
    public GameObject tower;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {  

        if (tower != null)
        {
            buildManager.SelectStage(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        
        buildManager.BuildTowerOn(this);
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color =startColor;
    }
}
