using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeedRatio = 0.5f;
    [SerializeField] float boostSpeedRatio = 1.5f;
    [SerializeField] float maxBoostSpeed = 50f;
    [SerializeField] float boostDuration = 1f;
    [SerializeField] float decelerationRate = 20f; // ���� �ӵ�

    float slowSpeed;
    float boostSpeed;
    float originalMoveSpeed;
    float boostTimer = 0f;
    bool isBoosting = false;
    bool isDecelerating = false;

    void Start()
    {
        slowSpeed = moveSpeed * slowSpeedRatio;
        boostSpeed = moveSpeed * boostSpeedRatio;
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        // �ν�Ʈ Ÿ�̸� ����
        if (isBoosting)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0f)
            {
                isBoosting = false;
                isDecelerating = true;
            }
        }

        // �ε巯�� ���� ó��
        if (isDecelerating)
        {
            moveSpeed = Mathf.MoveTowards(moveSpeed, originalMoveSpeed, decelerationRate * Time.deltaTime);

            if (Mathf.Approximately(moveSpeed, originalMoveSpeed))
            {
                moveSpeed = originalMoveSpeed;
                isDecelerating = false;
            }
        }

        float turnAmout = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmout);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            moveSpeed = maxBoostSpeed;
            boostTimer = boostDuration;
            isBoosting = true;
            isDecelerating = false; // �ν�Ʈ �߿� �������� ����
            Debug.Log("Boost!!!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
        isBoosting = false;
        isDecelerating = false;
    }
}
