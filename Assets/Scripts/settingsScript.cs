using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

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


public class settingsScript : MonoBehaviour
{
    public TMP_Dropdown languageDropDown;
    public TMP_Dropdown graphicsDropDown;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Image panelbrightness;

    private void Awake()
    {
        volumeSlider.value = GameManager.Instance.gameVolume;
        AudioListener.volume = GameManager.Instance.gameVolume;
        brightnessSlider.value = GameManager.Instance.gameBrightness;

        panelbrightness.gameObject.SetActive(true);                         // we active here because is anoying to work with this imagen active...

        SetLanguageValues();
        SetQualityValues();
    }



    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        GameManager.Instance.gameVolume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        GameManager.Instance.qualityIndex = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Setbrightness(float brightness)
    {
        GameManager.Instance.gameBrightness = brightness;
        panelbrightness.color = new Color(panelbrightness.color.r, panelbrightness.color.g, panelbrightness.color.b, brightness);
    }

    public void SetLanguage(int languageIndex)
    {
        if (languageIndex == 0)
        {
            GameManager.Instance.languageGame = "ENG";
        }
        else if (languageIndex == 1)
        {
            GameManager.Instance.languageGame = "ESP";
        }
        else if (languageIndex == 2)
        {
            GameManager.Instance.languageGame = "KOR";
        }
        else
        {
            GameManager.Instance.languageGame = "ENG";
        }
        updateTextLanguage();
        SetQualityValues();
        SetLanguageValues();
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

    private void SetQualityValues()
    {
        List<string> qualityList = new List<string>();
        string[] qualityName = new string[3];
        int language = GetCurrentLanguage();

        qualityName[0] = "Very Low";
        qualityName[1] = "Muy Bajo";
        qualityList.Add(qualityName[language]);

        qualityName[0] = "Low";
        qualityName[1] = "Bajo";
        qualityList.Add(qualityName[language]);

        qualityName[0] = "Medium";
        qualityName[1] = "Medio";
        qualityList.Add(qualityName[language]);

        qualityName[0] = "High";
        qualityName[1] = "Alto";
        qualityList.Add(qualityName[language]);

        qualityName[0] = "Very High";
        qualityName[1] = "Muy Alto";
        qualityList.Add(qualityName[language]);

        graphicsDropDown.ClearOptions();
        graphicsDropDown.AddOptions(qualityList);
        graphicsDropDown.GetComponent<TMP_Dropdown>().SetValueWithoutNotify(GameManager.Instance.qualityIndex);
    }

    private void SetLanguageValues()
    {
        List<string> LanguageList = new List<string>();
        string[] languageString = new string[3];
        int language = GetCurrentLanguage();

        languageString[0] = "English";
        languageString[1] = "Inglés";
        LanguageList.Add(languageString[language]);

        languageString[0] = "spanish language";
        languageString[1] = "Español";
        LanguageList.Add(languageString[language]);

        languageDropDown.ClearOptions();
        languageDropDown.AddOptions(LanguageList);

        languageDropDown.GetComponent<TMP_Dropdown>().SetValueWithoutNotify(GetCurrentLanguage());
    }

    private int GetCurrentLanguage()
    {
        int language = 0;

        if (GameManager.Instance.languageGame == "ENG")
        {
            language = 0;
        }
        else if (GameManager.Instance.languageGame == "ESP")
        {
            language = 1;
        }
        else if (GameManager.Instance.languageGame == "KOR")
        {
            language = 2;
        }
        else
        {   // english default language
            language = 0;
        }

        return language;
    }
}
