using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///�ҳ�enemy���ж�˭��HPֵ��С
/// <summary>


  
public class FindLowestHPEnemy : MonoBehaviour
{
    void Start()
    {
        // ���ú�������ӡ���е��˵�����  
        PrintAllEnemyNames();
    }

    void PrintAllEnemyNames()
    {
        //�����ҵ����б�ǩΪenemy��GameObject����Ϸ���壩
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");//�ؼ�
        //��ӡ���д��б�ǩΪenemy�����������
        foreach (GameObject enemy in enemies)
        {
            Debug.Log(enemy.name);
        }
        if (enemies.Length == 0)
        {
            Debug.Log("û���ҵ��κα�ǩΪ'enemy'�����塣");
        }

        if (enemies.Length > 0)
        {
            Enemy lowestHealthEnemyScript = null;
            float lowestHealth = float.MaxValue;

              
            foreach (GameObject enemy in enemies)
            {
                //���Դ� enemy GameObject �ϻ�ȡһ�����ӵ� Enemy �����Component��
                //��������������ô洢����Ϊ enemyScript �ı����У��������ǽ�HPȡ��  
                Enemy enemyScript = enemy.GetComponent<Enemy>();//�ؼ�
                //�򵥵�ȡ��Сֵ�ж�
                if (enemyScript != null && enemyScript.HP < lowestHealth)
                {
                      
                    lowestHealth = enemyScript.HP;
                    lowestHealthEnemyScript = enemyScript;
                }
            }
            //��ӡ�����СHPenemy��������Ѫ��
            if (lowestHealthEnemyScript != null)
            {
                Debug.Log("Enemy with lowest HP: " + lowestHealthEnemyScript.gameObject.name + ", HP: " + lowestHealthEnemyScript.HP);
            }
        }
    }
    
}
