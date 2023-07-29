using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Color hoverColor;
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
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (tower != null)
        {
            Debug.Log("Tut zanyato!!!");
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

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color =startColor;
    }
}
