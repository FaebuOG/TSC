using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UserInterfaceOverworld : MonoBehaviour
{
    // gives the UI acces to the inventory
    public InventoryObject inventory;
    
    [Header("Canvases")] 
    public GameObject canvasPauseMenu;
    public GameObject canvasInventory;
    public GameObject canvasDialoge;
    
    [Header("Inventory Panels")]
    public GameObject panelBackpack;
    public GameObject panelCards;
    public GameObject panelPoles;
    public GameObject panelCards1;
    public GameObject panelCards2;
    public GameObject panelCards3;

    [Header("Pausemenu first selected buttons")]
    public GameObject firstButtonPauseMenu;
    public GameObject firstButtonInventory;
    public GameObject firstButtonSettings;
    
    [Header("Inventory first selected buttons")]
    public GameObject firstButtonBagpack;
    public GameObject firstButtonCards;
    public GameObject firstButtonPoles;

    [Header("Dialoge first selected buttons")]
    public GameObject firstSelectedButtonDialoge;
    
    public int currentPanel = 1;
    private bool gamePaused = false;
    private bool inventoryActive = false;
    
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad.startButton.wasPressedThisFrame)
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        // Inventory switching input
        if (inventoryActive == true)
        {
            if(gamepad.rightShoulder.wasPressedThisFrame || gamepad.leftShoulder.wasPressedThisFrame)
            {
                SwitchInventoryPanels();
            }
        }
        
        // Close Inventory with east button
        if (inventoryActive == true && gamepad.buttonEast.wasPressedThisFrame)
        {
            canvasPauseMenu.SetActive(true);
            canvasInventory.SetActive(false);
            inventoryActive = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
        }
    }
    #region open/close Pausemenu
    
    // Pause and resume the game
    void Pause()
    {
        canvasPauseMenu.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(false);
        canvasDialoge.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
    }
    #endregion

    #region openInventory

    public void openInventory()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(true);
        panelCards.SetActive(true);
        panelCards1.SetActive(true);
        panelCards2.SetActive(false);
        panelCards3.SetActive(false);
        inventoryActive = true;
        EventSystem.current.SetSelectedGameObject(firstButtonInventory);
    }
    #endregion
    
    #region openDialogeCanvas

    public void openDialogeCanvas()
    {
        canvasPauseMenu.SetActive(false);
        canvasDialoge.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButtonDialoge);
    }
    #endregion
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    #region L1/R1 Navigation System
    void SwitchInventoryPanels()
    {
        // Gets the input from controller to switch the inventory panels
        var gamepad = Gamepad.current;
        if (gamepad.rightShoulder.wasPressedThisFrame)
        {
            if (currentPanel < 3)
            {
                currentPanel += 1;
            }
        }
        if (gamepad.leftShoulder.wasPressedThisFrame)
        {
            if (currentPanel > 1)
            {
                currentPanel -= 1;
            }
        }
        
        // Updates the current showed panel in the inventory
        switch (currentPanel)
        {
            case 1:
                panelBackpack.SetActive(true);
                panelCards.SetActive(false);
                panelPoles.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonBagpack);
                break;
            case 2:
                panelBackpack.SetActive(false);
                panelCards.SetActive(true);
                panelCards1.SetActive(true);
                panelCards2.SetActive(false);
                panelCards3.SetActive(false);
                panelPoles.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonCards);
                break;
            case 3:
                panelBackpack.SetActive(false);
                panelCards.SetActive(false);
                panelPoles.SetActive(true);
                EventSystem.current.SetSelectedGameObject(firstButtonPoles);
                break;
        }
    }
    #endregion

    #region Navigation Card Pages
    public void EnableFirstPage()
    {
        panelCards1.SetActive(true);
        panelCards2.SetActive(false);
        panelCards3.SetActive(false);
    }

    public void EnableSecondPage()
    {
        panelCards1.SetActive(false);
        panelCards2.SetActive(true);
        panelCards3.SetActive(false);
    }

    public void EnableThirdPage()
    {
        panelCards1.SetActive(false);
        panelCards2.SetActive(false);
        panelCards3.SetActive(true);
    }
    #endregion
}



