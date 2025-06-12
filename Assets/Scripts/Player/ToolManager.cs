using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public GameObject gunObject;
    public GameObject buildToolObject;

    private enum Tool { Gun, Build };
    private Tool currentTool = Tool.Gun;

    void Start()
    {
        EquipGun(); // Default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipBuildTool();
        }
    }

    void EquipGun()
    {
        currentTool = Tool.Gun;
        gunObject.SetActive(true);
        buildToolObject.SetActive(false);
    }

    void EquipBuildTool()
    {
        currentTool = Tool.Build;
        gunObject.SetActive(false);
        buildToolObject.SetActive(true);
    }
}
