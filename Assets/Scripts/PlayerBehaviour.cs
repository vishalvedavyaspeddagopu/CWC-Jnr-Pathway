using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
//********                     Creator: Oscar Castronuño                       Date: 03-16-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtLives;
    [SerializeField] private int livesPlayer = 1;
    [SerializeField] private GameObject minion;
 
    private int outOfBoundDownZ = -175;
    private int outOfBoundTopZ = -110;
    private int outOfBoundHoriX =23;

    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 35;

    // Start is called before the first frame update
    void Start()
    {
        changeLive(0);
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CheckOutofBounds();
    }

    private void CheckOutofBounds()
    {
        if (transform.position.z < outOfBoundDownZ || transform.position.z > outOfBoundTopZ)
            transform.Translate(Vector3.forward * Time.deltaTime * speed * -verticalInput);

        if (livesPlayer > 12)
        {
            outOfBoundHoriX = 17;
        }
        else if (livesPlayer > 1)
        {
            outOfBoundHoriX = 19;
        }
        else
        {
            outOfBoundHoriX = 23;
        }

        if (transform.position.x > outOfBoundHoriX || transform.position.x < -outOfBoundHoriX)
            transform.Translate(Vector3.right * Time.deltaTime * speed * -horizontalInput);
    }

    // Moves the player based on arrow/asdw key input
    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //playerRb.AddForce(Vector3.forward * speed * verticalInput);
        //playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

   public void changeLive(int num)
    {
        livesPlayer = livesPlayer + num;
        SumonMinion();
        UpdateTxtLives();

        if (livesPlayer <= 0)
        {
            Time.timeScale = 0f;
            GameObject.Find("scene").GetComponent<MenuControler>().activeLose();
        }

    }

    private void UpdateTxtLives()
    {
        txtLives.text = "" + livesPlayer;
    }

    private void SumonMinion()
    {
        GameObject formation = transform.GetChild(1).gameObject;    // 0 canvas, 1 formation

        if (livesPlayer < 25)
        {
            for (int x = 0; x < formation.transform.childCount; x++)
            {
                if (x < livesPlayer)
                {
                    formation.transform.GetChild(x).gameObject.SetActive(true);
                }
                else
                {
                    formation.transform.GetChild(x).gameObject.SetActive(false);
                }
            }
        }

    }

    public void setSoldiers(bool answerCorrect, int damage)
    {
        if (answerCorrect)
        {
            changeLive(15);
        }
        else
        {
            changeLive(damage);
        }
    }

    public int GetLivesPlayer()
    {
        return livesPlayer;
    }

}
