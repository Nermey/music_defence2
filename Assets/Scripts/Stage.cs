using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    private GameObject tower;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Tut zanyato!!!");
            return;
        }

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color =startColor;
    }
}
