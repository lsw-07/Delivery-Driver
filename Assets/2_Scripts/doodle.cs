using UnityEngine;
/*
public class doodle : MonoBehaviour
{
    // ����߸� ��������Ʈ ������
    public GameObject spritePrefab;

    // ��������Ʈ ���� ���� (��)
    public float dropInterval = 2f;

    // ���� ��ġ ���� (x�� ����)
    public float spawnRangeX = 8f;

    // ���� ��ġ (y��)
    public float spawnY = 10f;

    // ������ �� �ݺ� ȣ�� ����
    void Start()
    {
        InvokeRepeating("SpawnSprite", 0f, dropInterval);
    }

    // ��������Ʈ ���� �Լ�
    void SpawnSprite()
    {
        // x�� ��ġ�� �����ϰ�, y���� ������ ���
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnY, 0);
        GameObject sprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);

        // Rigidbody2D�� ������ �߰� ó�� ����
        Rigidbody2D rb = sprite.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // �ʿ�� ���� �ϰ��� ���� ���� �߰� (�ɼ�)
            rb.AddForce(Vector2.down * 5f, ForceMode2D.Impulse);
        }
    }
}
*/