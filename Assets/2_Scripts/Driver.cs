using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float turnSpeed = 100f;
    //[SerializeField] float maxSpeed = 25f;
    //public float brakePower = 2f;  
    //public float acceleration = 5f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeedRatio = 0.5f;
    [SerializeField] float boostSpeedRatio = 1.5f;

    float slowSpeed;
    float boostSpeed;
    
    
    void Start()
    {
        slowSpeed = moveSpeed * slowSpeedRatio;
        boostSpeed = moveSpeed * boostSpeedRatio;
        
    }

    void Update()
    {
        float turnAmout = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -turnAmout);
        transform.Translate(0, moveAmount, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boost!!!!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

}
