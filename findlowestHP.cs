using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///找出enemy并判断谁的HP值最小
/// <summary>


  
public class FindLowestHPEnemy : MonoBehaviour
{
    void Start()
    {
        // 调用函数来打印所有敌人的名字  
        PrintAllEnemyNames();
    }

    void PrintAllEnemyNames()
    {
        //索引找到所有标签为enemy的GameObject（游戏物体）
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");//关键
        //打印所有带有标签为enemy的物体的名字
        foreach (GameObject enemy in enemies)
        {
            Debug.Log(enemy.name);
        }
        if (enemies.Length == 0)
        {
            Debug.Log("没有找到任何标签为'enemy'的物体。");
        }

        if (enemies.Length > 0)
        {
            Enemy lowestHealthEnemyScript = null;
            float lowestHealth = float.MaxValue;

              
            foreach (GameObject enemy in enemies)
            {
                //尝试从 enemy GameObject 上获取一个附加的 Enemy 组件（Component）
                //并将该组件的引用存储在名为 enemyScript 的变量中，在这里是将HP取出  
                Enemy enemyScript = enemy.GetComponent<Enemy>();//关键
                //简单的取最小值判断
                if (enemyScript != null && enemyScript.HP < lowestHealth)
                {
                      
                    lowestHealth = enemyScript.HP;
                    lowestHealthEnemyScript = enemyScript;
                }
            }
            //打印最后最小HPenemy的名字与血量
            if (lowestHealthEnemyScript != null)
            {
                Debug.Log("Enemy with lowest HP: " + lowestHealthEnemyScript.gameObject.name + ", HP: " + lowestHealthEnemyScript.HP);
            }
        }
    }
    
}
