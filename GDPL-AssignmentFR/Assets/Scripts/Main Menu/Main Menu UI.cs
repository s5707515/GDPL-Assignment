using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    

    [SerializeField] private GameObject menuButtons;

   

    [SerializeField] private GameObject instructionImages;


    private void Start()
    {
        instructionImages.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void DisplayInstructions()
    {
        menuButtons.SetActive(false);
        instructionImages.SetActive(true);
        
    }

    public void DisplayMainMenu()
    {
        instructionImages.SetActive(false);
        menuButtons.SetActive(true);
    }

    
}
