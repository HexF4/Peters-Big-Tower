using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (menu != null)
            {
                // Toggle once
                bool isOpen = !menu.activeSelf;
                menu.SetActive(isOpen);

                // Handle cursor
                Cursor.visible = isOpen;
                Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
}
