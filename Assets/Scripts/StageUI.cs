using UnityEngine;

public class StageUI : MonoBehaviour
{
    private Stage target;

    public GameObject ui;
    public void SetTarget(Stage _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
