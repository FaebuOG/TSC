using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UserInterfaceOverworld : MonoBehaviour
{
    
    [Header("Script References")]
    public InventoryObject inventory;
    
    #region Inventory Canvas/Panels
    [Header("Canvases")] 
    public GameObject canvasPauseMenu;
    public GameObject canvasInventory;
    public GameObject canvasDialoge;
    public GameObject canvasSettings;

    [Header("Panels Inventory")] 
    public GameObject panelInventory;
    public GameObject panelBackpack;
    public GameObject panelLineUpTeam;
    public GameObject panelLineUpAbilitys;
    
    [Header("Panels equip cards")]
    public GameObject panelEquipPoleCards;
    public GameObject panelEquipAbilityCards;

    [Header("Text equip cards")]
    public Text EquipPoleText;
    public Text EquipAbilityText;
    
    // Buttons
    [Header("Buttons Pausenmenu")]
    public GameObject firstButtonPauseMenu;
    public GameObject firstButtonInventory;
    public GameObject firstButtonSettings;
    
    [Header("Buttons Inventory")]
    public GameObject firstButtonBagpack;
    public GameObject firstButtonLineUpPoleCards;
    public GameObject firstButtonLineUpAbilityCards;
    #endregion
    
    #region Inventory Submenu Canvas/Panels/Buttons
    [Header("Panels LineUP Team")]
    public GameObject panelPoleCards1;
    public GameObject panelPoleCards2;
    public GameObject panelPoleCards3;
    
    [Header("Panels LineUP Team")]
    public GameObject panelAbilityCards1;
    public GameObject panelAbilityCards2;
    public GameObject panelAbilityCards3;
    
    // Buttons
    [Header("Buttons LineUps")]
    public GameObject firstButtonPoleCardPage1;
    public GameObject firstButtonPoleCardPage2;
    public GameObject firstButtonPoleCardPage3;

    public GameObject firstButtonAbilityCardPage1;
    public GameObject firstButtonAbilityCardPage2;
    public GameObject firstButtonAbilityCardPage3;

    public GameObject firstButtonAbilityCard;

    public GameObject firstButtonLeftArrowPoles;
    public GameObject firstButtonRightArrowPoles;

    public GameObject firstButtonLeftArrowAbilitys;
    public GameObject firstButtonRightArrowAbilitys;
    #endregion
    
    [Header("Dialoge first selected buttons")]
    public GameObject firstSelectedButtonDialoge;
    
    public int currentPanel = 1;
    private bool gamePaused = false;
    private bool inventoryActive = false;

    
    [SerializeField] public Text textMoney;
    [SerializeField] public Text textWood;

    void Update()
    {
        firstButtonPoleCardPage1 = FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1;
        firstButtonAbilityCardPage1 = FirstButtonCardSelection.FirstButtonLineUpAbilityCardPage1;

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
        
        textMoney.text = inventory.money.ToString();
        textWood.text = inventory.wood.ToString();

        #region Inventory switching input

        if (inventoryActive == true)
        {
            if(gamepad.rightShoulder.wasPressedThisFrame || gamepad.leftShoulder.wasPressedThisFrame)
            {

            SwitchInventoryPanels();
            }
        }
        #endregion
        
        #region close Inventory with east button
        if (inventoryActive == true && gamepad.buttonEast.wasPressedThisFrame)
        {
            canvasPauseMenu.SetActive(true);
            canvasInventory.SetActive(false);
            inventoryActive = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
        }
        #endregion
        #region close LineUp selection with east button
        if (panelEquipPoleCards.activeInHierarchy && gamepad.buttonEast.wasPressedThisFrame)
        {
            inventoryActive = true;
            panelInventory.SetActive(true);
            panelEquipPoleCards.SetActive(false);
            EnableFirstPoleCardPage();

            EventSystem.current.SetSelectedGameObject(firstButtonLineUpPoleCards);
        }
        if (panelEquipAbilityCards.activeInHierarchy && gamepad.buttonEast.wasPressedThisFrame)
        {
            inventoryActive = true;
            panelInventory.SetActive(true);
            panelEquipAbilityCards.SetActive(false);
            EnableFirstAbilityCardPage();

            EventSystem.current.SetSelectedGameObject(firstButtonLineUpAbilityCards);
        }
        #endregion
    }

    #region open/close Pausemenu
    void Pause()
    {
        canvasPauseMenu.SetActive(true);
        gamePaused = true;
        //Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
    }

    public void Resume()
    {
        // unpause the game
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
            
        GameStateManager.Instance.SetState(newGameState);
        
        // close UI
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(false);
        canvasDialoge.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;
    }
    #endregion

    #region openInventory
    [SerializeField] InventoryUI inventoryUI;

    public void openInventory()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(true);
        panelBackpack.SetActive(true);

        inventoryActive = true;
        EventSystem.current.SetSelectedGameObject(firstButtonInventory);
        inventoryUI.UpdatePoleCardList();
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
        SceneManager.LoadScene(0);
    }
   

    #region L1/R1 Navigation System 

    // TODO: Animate the buttons when switching
    void SwitchInventoryPanels()
    {
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

        switch (currentPanel)
        {
            case 1:
                panelBackpack.SetActive(true);
                panelLineUpTeam.SetActive(false);
                panelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonBagpack);
                break;
            case 2:
                panelBackpack.SetActive(false);
                panelLineUpTeam.SetActive(true);
                panelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonLineUpPoleCards);
                break;
            case 3:
                panelBackpack.SetActive(false);
                panelLineUpTeam.SetActive(false);
                panelLineUpAbilitys.SetActive(true);
                EventSystem.current.SetSelectedGameObject(firstButtonLineUpAbilityCards);
                break;

        }

    }
    #endregion
    
    public enum ActivePage
    {
        Page1,
        Page2,
        Page3
    }

    #region Navigation Pole Card Pages

    ActivePage activePolePage = ActivePage.Page1;

    public void EnableNextPage()
    {
        switch (activePolePage)
        {
            case ActivePage.Page1:
                EventSystem.current.SetSelectedGameObject(firstButtonRightArrowPoles);
                EnableSecondPoleCardPage();
                break;
            case ActivePage.Page2:
                EventSystem.current.SetSelectedGameObject(firstButtonRightArrowPoles);
                EnableThirdPoleCardPage();
                break;
            case ActivePage.Page3:
                break;
            default:
                break;
        }
    }

    public void EnablePreviousPage()
    {
        switch (activePolePage)
        {
            case ActivePage.Page1:
                break;
            case ActivePage.Page2:
                EventSystem.current.SetSelectedGameObject(firstButtonLeftArrowPoles);
                EnableFirstPoleCardPage();
                break;
            case ActivePage.Page3:
                EventSystem.current.SetSelectedGameObject(firstButtonLeftArrowPoles);
                EnableSecondPoleCardPage();
                break;
            default:
                break;
        }
    }

    public void EnableFirstPoleCardPage()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCardPage1);
        activePolePage = ActivePage.Page1;
        panelPoleCards1.SetActive(true);
        panelPoleCards2.SetActive(false);
        panelPoleCards3.SetActive(false);
    }

    public void EnableSecondPoleCardPage()
    {
        activePolePage = ActivePage.Page2;
        panelPoleCards1.SetActive(false);
        panelPoleCards2.SetActive(true);
        panelPoleCards3.SetActive(false);
    }

    public void EnableThirdPoleCardPage()
    {
        activePolePage = ActivePage.Page3;
        panelPoleCards1.SetActive(false);
        panelPoleCards2.SetActive(false);
        panelPoleCards3.SetActive(true);
    }

    #endregion

    #region PoleCard Button methods
    // When a button for a pole is selected, the current pole to equip the cards on is selected.
    public void SetActivePoleMain()
    {
        LineUpController.CardType = true;
        EquipPoleText.text = "Equip Main Pole\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 0;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPoleCardPage();
        
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCardPage1);
    }
    public void SetActivePoleFirst()
    {
        LineUpController.CardType = true;
        EquipPoleText.text = "Equip Crew Pole 1\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 1;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPoleCardPage();
        
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCardPage1);
    }
    public void SetActivePoleSecond()
    {
        LineUpController.CardType = true;
        EquipPoleText.text = "Equip Crew Pole 2\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 2;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPoleCardPage();

        EventSystem.current.SetSelectedGameObject(firstButtonPoleCardPage1);
    }
    public void SetActivePoleThird()
    {
        LineUpController.CardType = true;
        EquipPoleText.text = "Equip Crew Pole 3\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 3;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPoleCardPage();
        
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCardPage1);
    }

    #endregion


    #region Navigation Ability Card Pages

    ActivePage activeAbilityPage = ActivePage.Page1;

    public void EnableNextAbilityPage()
    {
        switch (activeAbilityPage)
        {
            case ActivePage.Page1:
                EventSystem.current.SetSelectedGameObject(firstButtonRightArrowAbilitys);
                EnableSecondAbilityCardPage();
                break;
            case ActivePage.Page2:
                EventSystem.current.SetSelectedGameObject(firstButtonRightArrowAbilitys);
                EnableThirdAbilityCardPage();
                break;
            case ActivePage.Page3:
                break;
            default:
                break;
        }
    }

    public void EnablePreviousAbilityPage()
    {
        switch (activeAbilityPage)
        {
            case ActivePage.Page1:
                break;
            case ActivePage.Page2:
                EventSystem.current.SetSelectedGameObject(firstButtonLeftArrowAbilitys);
                EnableFirstAbilityCardPage();
                break;
            case ActivePage.Page3:
                EventSystem.current.SetSelectedGameObject(firstButtonLeftArrowAbilitys);
                EnableSecondAbilityCardPage();
                break;
            default:
                break;
        }
    }

    public void EnableFirstAbilityCardPage()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonAbilityCardPage1);
        activeAbilityPage = ActivePage.Page1;
        panelAbilityCards1.SetActive(true);
        panelAbilityCards2.SetActive(false);
        panelAbilityCards3.SetActive(false);
    }

    public void EnableSecondAbilityCardPage()
    {
        activeAbilityPage = ActivePage.Page2;
        panelAbilityCards1.SetActive(false);
        panelAbilityCards2.SetActive(true);
        panelAbilityCards3.SetActive(false);
    }

    public void EnableThirdAbilityCardPage()
    {
        activeAbilityPage = ActivePage.Page3;
        panelAbilityCards1.SetActive(false);
        panelAbilityCards2.SetActive(false);
        panelAbilityCards3.SetActive(true);
    }

    #endregion

    #region AbilityCard Button methods
    // When a button for a pole is selected, the current pole to equip the cards on is selected.
    public void SetActiveAbilityMain()
    {
        LineUpController.CardType = false;
        EquipAbilityText.text = "Equip Main Ability\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 0;

        panelInventory.SetActive(false);
        panelEquipAbilityCards.SetActive(true);
        EnableFirstAbilityCardPage();

        EventSystem.current.SetSelectedGameObject(firstButtonAbilityCardPage1);
    }
    public void SetActiveAbilityFirst()
    {
        LineUpController.CardType = false;
        EquipAbilityText.text = "Equip Crew Pole 1\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 1;

        panelInventory.SetActive(false);
        panelEquipAbilityCards.SetActive(true);
        EnableFirstAbilityCardPage();

        EventSystem.current.SetSelectedGameObject(firstButtonAbilityCardPage1);
    }
    public void SetActiveAbilitySecond()
    {
        LineUpController.CardType = false;
        EquipAbilityText.text = "Equip Crew Pole 2\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 2;

        panelInventory.SetActive(false);
        panelEquipAbilityCards.SetActive(true);
        EnableFirstAbilityCardPage();

        EventSystem.current.SetSelectedGameObject(firstButtonAbilityCardPage1);
    }
    public void SetActiveAbilityThird()
    {
        LineUpController.CardType = false;
        EquipAbilityText.text = "Equip Crew Pole 3\nCards";
        inventoryActive = false;
        LineUpController.ActivePole = 3;

        panelInventory.SetActive(false);
        panelEquipAbilityCards.SetActive(true);
        EnableFirstAbilityCardPage();

        EventSystem.current.SetSelectedGameObject(firstButtonAbilityCardPage1);
    }
    #endregion
}



