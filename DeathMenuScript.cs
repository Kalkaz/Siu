using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public Button mainMenuButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
