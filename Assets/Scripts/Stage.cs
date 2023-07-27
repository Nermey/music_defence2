using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    private GameObject tower;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        if (tower != null)
        {
            Debug.Log("Tut zanyato!!!");
            return;
        }

        GameObject towerToBuild = buildManager.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTowerToBuild() == null)
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
