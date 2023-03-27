using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
//********                     Creator: Oscar Castronuño                       Date: 03-15-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class repeatGround : MonoBehaviour
{
    public GameObject QuestionPref1;
    public GameObject QuestionPref2;
    [SerializeField] private GameObject spawnerObj;
    [SerializeField] private float speed = 10;
    private Vector3 startPos;
    private float repeatHeight;
    private Vector3 QuestionPref2Pos = new Vector3(0, 0, 150);
    private int outOfBoundsZ = -200;
    private int currentWave = 0;
    private bool isLateWave = false;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        speed = GameManager.Instance.speedMap;
        repeatHeight = (GetComponent<BoxCollider>().size.z / 4)* transform.localScale.z;
        startPos = transform.position;
        isLateWave = false;
        spwanEnemy(false);
    }

    // Update is called once per frame
    void Update()
    {
        //MoveGround(); 
        if (currentWave > 10)
        {
            if (!isLateWave)
                spwanEnemy(true);
        }
        
        MoveQuestions();

    }

    private void MoveGround()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < startPos.z - repeatHeight)
        {
            transform.position = startPos;
        }
    }

    private void MoveQuestions()
    {
        QuestionPref1.transform.Translate(Vector3.back * Time.deltaTime * speed);
        QuestionPref2.transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (QuestionPref1.transform.position.z < outOfBoundsZ)
        {
            if (currentWave < 9)
                resetQuestion(1);
            else
                currentWave = currentWave + 1;
        }

        if (QuestionPref2.transform.position.z < outOfBoundsZ)
        {
            if (currentWave < 9)
                resetQuestion(2);
            else
                currentWave = currentWave + 1;
        }
    }

    public void resetQuestion(int questionActive)
    {   // int questionActive: 1 - questoinPref1, 2 - QuestionPref2

        if (questionActive == 1)
        {
            QuestionPref1.transform.position = QuestionPref2Pos;
            QuestionPref1.transform.GetChild(0).gameObject.SetActive(true);
            QuestionPref1.transform.GetChild(0).GetComponent<QuestionPref>().CreateQuestion();
        }
        else
        {
            QuestionPref2.transform.position = QuestionPref2Pos;
            QuestionPref2.transform.GetChild(0).gameObject.SetActive(true);
            QuestionPref2.transform.GetChild(0).GetComponent<QuestionPref>().CreateQuestion();
        }
        currentWave = currentWave + 1;

        if (currentWave < 3)
        {
            spwanEnemy(false);
        }
        else if (currentWave < 6)
        {
            spwanEnemy(false); 
            spwanEnemy(false);
        }
        else
        {
            spwanEnemy(false);
            spwanEnemy(false);
            spwanEnemy(false);
        }


    }

    private void spwanEnemy(bool isBoss)
    {
        isLateWave = isBoss;
        spawnerObj.GetComponent<Spawner>().GenerateEnemy(currentWave, isBoss);
    }

}
