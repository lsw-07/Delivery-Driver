using UnityEngine;
/*
public class mytest : MonoBehaviour
{
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float maxSpeed = 300f;
    [SerializeField] float slowSpeedRatio = 0.5f;
    [SerializeField] float boostSpeedRatio = 1.5f;
    [SerializeField] float brakeDeceleration = 5f; // [브레이크 기능 추가] 브레이크 감속 속도

    float slowSpeed;
    float boostSpeed;
    float currentSpeed;

    void Start()
    {
        slowSpeed = moveSpeed * slowSpeedRatio;
        boostSpeed = moveSpeed * boostSpeedRatio;
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveInput = Input.GetAxis("Vertical");

        // [브레이크 기능 추가] 브레이크 버튼을 누르면 속도를 점진적으로 줄임
        if (Input.GetKey(KeyCode.LeftShift)) // 브레이크 키 설정 (Left Shift)
        {
            currentSpeed = Mathf.Max(slowSpeed, currentSpeed - brakeDeceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        float moveAmount = moveInput * currentSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0, moveAmount, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = slowSpeed;
    }
}
*/