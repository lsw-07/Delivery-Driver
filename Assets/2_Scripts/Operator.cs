using System;
using UnityEngine;

public class Operator : MonoBehaviour
{
    private void Start()
    {
        ex1();
        ex2();
        ex3();
    }

    private void ex3()
    {
        int level = 6;
        bool hasSpecialItem = true;
        bool isInBattle = true;

        // Ʋ�ȴ� �ڵ�if (level >= 5)
        {
            if (level >= 5 && hasSpecialItem && isInBattle)  //���� 
            {
                Debug.Log("������ ��� ����");
            }
            else
            {
                Debug.Log("������ ��� �Ұ�");
            }
        }
        //else
        
           //Ʋ�ȴ� �ڵ� Debug.Log("������ ��� �Ұ�");
        
    }

    private void ex2()
    {
        int mathScore = 95;
        int englishScore = 85;
        float average = (mathScore + englishScore) / 2f;

        if (mathScore >= 60 && englishScore >= 60) 
        {
            if (average >= 90)
            {
                Debug.Log("��� �հ�");
            }
            else
            {
                Debug.Log("�Ϲ� �հ�");
            }
        }
        else
        {
            Debug.Log("���հ�");
        }
    }



    private static void ex1()
    {
        int healt = 10;

        if (healt > 70)
        {
            Debug.Log("�ǰ��ؿ�");
        }
        else if (healt > 30)
        {
            Debug.Log("�ణ ���ƾ��");
        }
        else if (healt > 0)
        {
            Debug.Log("�����ؿ�");
        }
        else
        {
            Debug.Log("���");
        }
    }
}
