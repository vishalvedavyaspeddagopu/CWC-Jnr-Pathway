using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class txt_controler : MonoBehaviour
{
    private GameObject text_object;
    private string[] txt_text = new string[3];  // 0 ENG, 1 ESP, 2 KOR
    private string txtname;
    private int txtlanguage;

    void Start()
    {
        chosseLanguage();
    }

    private void getLanguage()
    {
        if (GameManager.Instance.languageGame == "ENG")
        {
            txtlanguage = 0;
        }
        else if (GameManager.Instance.languageGame == "ESP")
        {
            txtlanguage = 1;
        }
        else if (GameManager.Instance.languageGame == "KOR")
        {
            txtlanguage = 2;
        }
        else
        {   // english default language
            txtlanguage = 0;
        }
    }

    public void chosseLanguage()
    {
        txtname = this.name;
        getLanguage();
        switch (txtname)
        {
            case "txt_Start":
                txt_text[0] = "Start";
                txt_text[1] = "Comenzar";
                break;
            case "txt_Settings":
                txt_text[0] = "Settings";
                txt_text[1] = "Opciones";
                break;
            case "txt_Hall":
                txt_text[0] = "Hall Of Fame";
                txt_text[1] = "Salon de la Fama";
                break; 
            case "txt_Language":
                txt_text[0] = "Language: ";
                txt_text[1] = "Idioma: ";
                break;
            case "txt_Graphics":
                txt_text[0] = "Graphics: ";
                txt_text[1] = "Gráficos: ";
                break;
            case "txt_Volume":
                txt_text[0] = "Volume: ";
                txt_text[1] = "Volumen: ";
                break;
            case "txt_Brightness":
                txt_text[0] = "Brightness: ";
                txt_text[1] = "Brillo: ";
                break;
            case "txt_save":
                txt_text[0] = "Save";
                txt_text[1] = "Guardar";
                break; 
            case "txt_maxlvl":
                txt_text[0] = "" + GameManager.Instance.currentLevel;
                txt_text[1] = "" + GameManager.Instance.currentLevel;
                break;
            case "txt_congratu":
                txt_text[0] = "Congratulations";
                txt_text[1] = "Felicidades";
                break;
            case "txt_Lose":
                txt_text[0] = "Try again";
                txt_text[1] = "Intentalo de nuevo";
                break;
            case "txt_retry":
                txt_text[0] = "Retry";
                txt_text[1] = "Reintentar";
                break;
            case "txt_menu":
                txt_text[0] = "Menu";
                txt_text[1] = "Menu";
                break;
            case "txt_nextLvl":
                txt_text[0] = "Next Level";
                txt_text[1] = "Siguiente Nivel";
                break;
        } // end switch(txtname)

        text_object = GameObject.Find(txtname);                             // we find the item textmesh
        text_object.GetComponent<TextMeshProUGUI>().text = txt_text[txtlanguage];

    } //end chosseLanguage

}
