using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button PlayGameButton;
    public Button QuitGameButton;
    
    private void Start()
    {
        PlayGameButton.onClick.AddListener(PlayGame);
        QuitGameButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}