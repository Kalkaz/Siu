using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsScript : MonoBehaviour
{
    bool skillsMenuOpened = false;
    public GameObject skillsMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (skillsMenuOpened)
            {
                CloseSkills();
            }
            else UpdateSkills();
        }
    }
    
    void CloseSkills()
    {
        skillsMenu.SetActive(false);
        Time.timeScale = 1;
        skillsMenuOpened = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void UpdateSkills()
    {
        skillsMenu.SetActive(true);
        Time.timeScale = 0;
        skillsMenuOpened = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}