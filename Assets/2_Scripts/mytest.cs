/*
public class mytest : MonoBehaviour
{
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float maxSpeed = 25f;
    public float brakePower = 2f;  
    public float acceleration = 5f;
    [SerializeField] float slowSpeedRatio = 0.5f;
    [SerializeField] float boostSpeedRatio = 1.5f;
    [SerializeField] float brakeDeceleration = 5f; // [�극��ũ ��� �߰�] �극��ũ ���� �ӵ�

    public float brakePower = 2f;  
    public float acceleration = 5f;
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

        // [�극��ũ ��� �߰�] �극��ũ ��ư�� ������ �ӵ��� ���������� ����
        if (Input.GetKey(KeyCode.LeftShift)) // �극��ũ Ű ���� (Left Shift)
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


  float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * accleration);
        }

        float turnAmount = Input.GetAxis("Horizontal") * steering * speed * Time.fixedDeltaTime;
        // turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

        //Drift
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * driftFactor;
*/