using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public GameObject gunTool;
    public GameObject buildTool;

    void Start()
    {
        // Start with both tools deactivated
        gunTool.SetActive(false);
        buildTool.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press 1 to equip gun
        {
            gunTool.SetActive(true);
            buildTool.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // Press 2 to equip builder
        {
            gunTool.SetActive(false);
            buildTool.SetActive(true);
        }
    }
}
