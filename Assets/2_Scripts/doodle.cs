using UnityEngine;
/*
public class doodle : MonoBehaviour
{
    // 떨어뜨릴 스프라이트 프리팹
    public GameObject spritePrefab;

    // 스프라이트 생성 간격 (초)
    public float dropInterval = 2f;

    // 생성 위치 범위 (x축 랜덤)
    public float spawnRangeX = 8f;

    // 시작 위치 (y축)
    public float spawnY = 10f;

    // 시작할 때 반복 호출 시작
    void Start()
    {
        InvokeRepeating("SpawnSprite", 0f, dropInterval);
    }

    // 스프라이트 생성 함수
    void SpawnSprite()
    {
        // x축 위치는 랜덤하게, y축은 고정값 사용
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnY, 0);
        GameObject sprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);

        // Rigidbody2D가 있으면 추가 처리 가능
        Rigidbody2D rb = sprite.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 필요시 강제 하강을 위한 힘을 추가 (옵션)
            rb.AddForce(Vector2.down * 5f, ForceMode2D.Impulse);
        }
    }
}
*/