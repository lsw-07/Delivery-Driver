using UnityEngine;

public class House 
{
    public string tv = "�Ž�";
    private string diary = "��� ���̾";
    protected string secretKey = "�� ��й�ȣ";

    private int age = 12;

    public string GetDiary()
    {
      Driver driver = new Driver();

      return diary;
    }
}
