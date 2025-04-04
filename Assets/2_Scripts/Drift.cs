using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] float accleration = 20f;  //����/���� ���ӵ�
    [SerializeField] float steering = 10f;    //����ӵ�
    [SerializeField] float maxSpeed = 100f;   //�ִ� �ӵ� ����
    [SerializeField] float driftFactor = 0.95f; //�������� �� �̲�����

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * accleration);
        }

        //float turnAmount = Input.GetAxis("Horizontal") * steering * speed * Time.fixedDeltaTime;
        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

       //Drift
       Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
       Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

       rb.linearVelocity = forwardVelocity + sideVelocity * driftFactor;

    }
}
