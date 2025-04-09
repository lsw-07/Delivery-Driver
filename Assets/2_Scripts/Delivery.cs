using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delay = 0.3f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(0, 1, 0, 0.5f);
    [SerializeField] GameObject[] barrierObjects ; // ���� ���� �踮� �迭�� ����!

    bool hasChicken = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") && !hasChicken)
        {
            Debug.Log("ġŲ ȹ��!");
            hasChicken = true;
            spriteRenderer.color = hasChickenColor;
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("ġŲ ��� �Ϸ�!");
            spriteRenderer.color = noChickenColor;
            hasChicken = false;

            // ���� �踮�� ������Ʈ ��Ȱ��ȭ
            foreach (GameObject barrier in barrierObjects)
            {
                if (barrier != null)
                {
                    barrier.SetActive(false);
                    Debug.Log("�踮� ��������ϴ�: " + barrier.name);
                }
            }
        }
    }

    public bool HasDelivered()
    {
        return !hasChicken;
    }
}
