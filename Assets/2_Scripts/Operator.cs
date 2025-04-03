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

        // 틀렸던 코드if (level >= 5)
        {
            if (level >= 5 && hasSpecialItem && isInBattle)  //수정 
            {
                Debug.Log("아이템 사용 가능");
            }
            else
            {
                Debug.Log("아이템 사용 불가");
            }
        }
        //else
        
           //틀렸던 코드 Debug.Log("아이템 사용 불가");
        
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
                Debug.Log("우수 합격");
            }
            else
            {
                Debug.Log("일반 합격");
            }
        }
        else
        {
            Debug.Log("불합격");
        }
    }



    private static void ex1()
    {
        int healt = 10;

        if (healt > 70)
        {
            Debug.Log("건강해요");
        }
        else if (healt > 30)
        {
            Debug.Log("약간 지쳤어요");
        }
        else if (healt > 0)
        {
            Debug.Log("위험해요");
        }
        else
        {
            Debug.Log("사망");
        }
    }
}
