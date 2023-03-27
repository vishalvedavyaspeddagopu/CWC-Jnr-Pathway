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
//********                     Creator: Oscar Castronuño                       Date: 03-17-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtLives;
    [SerializeField] private int enemyPower = 1;
    public float speed = 33;

    public Rigidbody enemyRb;
    private GameObject playerTarget;
    public Vector3 movement;
    private bool isBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.Instance.speedMap;
        enemyRb = GetComponent<Rigidbody>();
        playerTarget = GameObject.Find("Player");

        UpdateTxtLives();
    }

    public void SetEnemyPower(int power, bool isBossIn)
    {
        enemyPower = power;
        if (isBossIn)
            transform.localScale = transform.localScale * 3;

        isBoss = isBossIn;

        UpdateTxtLives();
    }

    // Update is called once per frame
    void Update()
    {
        CalcMovement();
    }

    void FixedUpdate()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        enemyRb.MovePosition(enemyRb.position + movement * speed * Time.deltaTime);
    }

    private void CalcMovement()
    {
        if (transform.position.x - playerTarget.transform.position.x > 2)
            movement.x = -1;
        else if (transform.position.x - playerTarget.transform.position.x < -2)
            movement.x = 1;
        else
            movement.x = 0;

        if (transform.position.z - playerTarget.transform.position.z > 2)
            movement.z = -1;
        else if (transform.position.z - playerTarget.transform.position.z < -2)
            movement.z = 1;
        else
            movement.z = 0;

        movement.y = transform.position.y;
    }

    private void UpdateTxtLives()
    {
        txtLives.text = "" + enemyPower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerMinion"))
        {
            playerTarget.gameObject.GetComponent<PlayerBehaviour>().setSoldiers(false, -enemyPower);
            Destroy(gameObject);

            if (isBoss)
            {
                GameManager.Instance.NextLvlMap();
                GameObject.Find("scene").GetComponent<MenuControler>().activeWin();
            }

        }
    }


}
