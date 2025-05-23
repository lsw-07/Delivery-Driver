using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delay = 0.3f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(0, 1, 0, 0.5f);
    [SerializeField] GameObject[] barrierObjects; // 여러 개의 배리어를 배열로 선언!

    bool hasChicken = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 자동으로 "Barrier" 태그를 가진 모든 오브젝트를 찾아서 barrierObjects 배열에 저장
        GameObject[] foundBarriers = GameObject.FindGameObjectsWithTag("Barrier");
        if (foundBarriers.Length > 0)
        {
            barrierObjects = foundBarriers;
        }
        else
        {
            Debug.LogWarning("Barrier 태그를 가진 오브젝트를 찾지 못했습니다!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") && !hasChicken)
        {
            Debug.Log("치킨 획득!");
            hasChicken = true;
            spriteRenderer.color = hasChickenColor;
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("치킨 배달 완료!");
            spriteRenderer.color = noChickenColor;
            hasChicken = false;

            // 여러 배리어 오브젝트 비활성화
            foreach (GameObject barrier in barrierObjects)
            {
                if (barrier != null)
                {
                    barrier.SetActive(false);
                    Debug.Log("배리어가 사라졌습니다: " + barrier.name);
                }
            }
        }
    }
    public bool HasDelivered()
    {
        return !hasChicken;
    }
}
