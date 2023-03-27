using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//**************************************************************************************************************************************************************//
//********                                                                                                                                              ********//
//********              #####  ##     #####  #####   ####    ####   ####    ##   #####    #####    ###   ######  #####                                  ********//
//********              ##     ##     ##     ##     ##   #    ##   ##  ##   ##  ##       ##       ## ##    ##    ##                                     ********//
//********              #####  ##     #####  #####  #####     ##   ##   ##  ##  ##  ##   ##      #######   ##    #####                                  ********//
//********                 ##  ##     ##     ##     ##        ##   ##    ## ##  ##   ##  ##      ##   ##   ##       ##                                  ********//
//********              #####  #####  #####  #####  ##       ####  ##      ###   #####    #####  ##   ##   ##    #####                                  ********//
//********                                                                                                                                              ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//********                     Creator: Oscar Castronuño                       Date: 03-19-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class MenuControler : MonoBehaviour
{
    public GameObject p_Menu;
    public GameObject p_Settings;
    public GameObject p_Hall;
    public GameObject p_win;
    public GameObject p_isLose;

    public void SetMenuActive()
    {
        ActiveMenus(true, false, false);
    }

    public void SetSettingsActive()
    {
        ActiveMenus(false, true, false);
    }

    public void SetHallsActive()
    {
        ActiveMenus(false, false, true);
    }

    public void activeLose()
    {
        ActiveMenusLose(false, true);
    }

    public void activeWin()
    {
        ActiveMenusLose(true, false);
    }

    public void GoToGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); // game
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // Menu
    }

    private void ActiveMenus(bool menuB, bool settingsB, bool hallB)
    {
        p_Menu.gameObject.SetActive(menuB);
        p_Settings.gameObject.SetActive(settingsB);
        p_Hall.gameObject.SetActive(hallB);

        updateTextLanguage();
    }

    private void ActiveMenusLose(bool isWin, bool isLose)
    {
        p_win.gameObject.SetActive(isWin);
        p_isLose.gameObject.SetActive(isLose);

        updateTextLanguage();
    }

    public void updateTextLanguage()
    {
        GameObject[] allTxt;
        allTxt = GameObject.FindGameObjectsWithTag("textTag");

        foreach (GameObject currentText in allTxt)
        {
            //Debug.Log("currentText: " + currentText.gameObject.name);
            currentText.GetComponent<txt_controler>().chosseLanguage();
        }
    }
}
