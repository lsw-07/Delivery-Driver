using UnityEngine;

public class Player
{
    public int health = 100;
    public static int PlayerCount = 0;
    public Player()
    {
        PlayerCount++;
    }


    public void TakeDamge(int damge)
    {
        health = health - damge;
    } 

    public void Attack()
    {
        int damge = 10;
        Debug.Log("���ݷ�: " + damge);
    }
    public void Defend()
    {
        int damge = 5;
        Debug.Log("����: " + damge);
    }

}
