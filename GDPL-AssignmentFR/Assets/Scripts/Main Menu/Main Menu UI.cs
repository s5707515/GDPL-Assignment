using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [Header("Menus:")]

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject instructionsMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject enemiesMenu;



    public void QuitGame() //Close the game
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }


    public void SwitchMenu(int transitionID) //Method called by buttons to switch which UI menu is on screen 
    {
        switch(transitionID)
        {
            case 0: //Main Menu -> Instructions

                MenuToMenu(mainMenu, instructionsMenu);
                break;

            case 1: //Instructions -> Main Menu

                MenuToMenu(instructionsMenu, mainMenu);
                break;

            case 2: //Instructions -> Controls

                MenuToMenu(instructionsMenu, controlsMenu);
                break;

            case 3: //Controls -> Instructions

                MenuToMenu(controlsMenu, instructionsMenu);
                break;

            case 4: //Instructions -> Enemies

                MenuToMenu(instructionsMenu, enemiesMenu);
                break;

            case 5: //Enemies -> Instructions

                MenuToMenu(enemiesMenu, instructionsMenu);
                break;

            default:

                Debug.Log("TransitionID: " + transitionID + "is N/A!!");

                break;


        }
    }

    public void MenuToMenu(GameObject startMenu, GameObject endMenu) //Switch which UI submenu is active
    {
        startMenu.SetActive(false);
        endMenu.SetActive(true);
    }

    
}
