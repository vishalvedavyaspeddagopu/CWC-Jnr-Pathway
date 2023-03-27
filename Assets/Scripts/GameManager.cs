using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int currentLevel;
    public float speedMap;
    public string languageGame;
    public int qualityIndex;
    public float gameVolume;
    public float gameBrightness;

    [System.Serializable]
    class SaveData
    {
        public int currentLevel;
        public float speedMap;
        public string languageGame;
        public int qualityIndex;
        public float gameVolume;
        public float gameBrightness;
    }

    void Awake()
    {   // This code enables you to access the MainManager object from any other script.  

        if (Instance != null)
        {   // start of new code
            Destroy(gameObject);
            return;
        }   // end of new code

        // You can now call MainManager.Instance from any other script 
        Instance = this;
        // marks the MainManager GameObject attached to this script not to be destroyed when the scene changes
        DontDestroyOnLoad(gameObject);

        //SaveAllData();

        LoadAllData();

    }

    public void SaveAllData()
    {
        SaveData data = new SaveData();
        data.currentLevel = currentLevel;
        data.speedMap = speedMap;
        data.languageGame = languageGame;
        data.qualityIndex = qualityIndex;
        data.gameVolume = gameVolume;
        data.gameBrightness = gameBrightness;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadAllData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentLevel = data.currentLevel;
            speedMap = data.speedMap;
            languageGame = data.languageGame;
            qualityIndex = data.qualityIndex;
            gameVolume = data.gameVolume;
            gameBrightness = data.gameBrightness;
        }
    }

    public void NextLvlMap()
    {
        currentLevel = currentLevel + 1;
        speedMap = speedMap + 0.5f;
        SaveAllData();
    }
}
