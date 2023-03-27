using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Cont : EnemyControler
{
    private void moveEnemy()
    {
        base.enemyRb.MovePosition(base.enemyRb.position + base.movement * base.speed/2 * Time.deltaTime);
    }
}
