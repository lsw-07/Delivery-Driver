using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [SerializeField] float delay = 0.3f;
    [SerializeField] Color noChickenColor = new Color(1,1,1,1);
    [SerializeField] Color hasChickenColor = new Color(0,1,0,0.5f);

    bool hasChicken = false;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") && !hasChicken )
        {
            Debug.Log("Ä¡Å² È¹µæ!");
            hasChicken = true;
            spriteRenderer.color = hasChickenColor;
            Destroy(collision.gameObject, delay); 
        }
        if (collision.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("Ä¡Å² ¹è´Þ ¿Ï·á!");
            spriteRenderer.color = noChickenColor;
            hasChicken = false; 
        }
    }
}

