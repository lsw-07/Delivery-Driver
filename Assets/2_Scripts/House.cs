using UnityEngine;

public class House 
{
    public string tv = "거실";
    private string diary = "비밀 다이어리";
    protected string secretKey = "집 비밀번호";

    private int age = 12;

    public string GetDiary()
    {
      Driver driver = new Driver();

      return diary;
    }
}
