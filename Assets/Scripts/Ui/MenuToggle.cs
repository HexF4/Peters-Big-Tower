using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (menu != null)
                menu.SetActive(!menu.activeSelf);
        }
    }
}