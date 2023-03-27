using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyList;
    
    public void GenerateEnemy(int round, bool isBoss)
    {
        int posY = 0;
        if (isBoss)
            posY = 2;

        Vector3 newPos = this.transform.position + new Vector3(Random.Range(0,10), posY, Random.Range(0, 10));
        GameObject myEnemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)], newPos, Quaternion.identity, this.transform) as GameObject;
        myEnemy.GetComponent<EnemyControler>().SetEnemyPower(Random.Range(1, round), false);
        if (isBoss)
        {
            myEnemy.GetComponent<EnemyControler>().SetEnemyPower(round * 2, true);
        }
            
    }
}
