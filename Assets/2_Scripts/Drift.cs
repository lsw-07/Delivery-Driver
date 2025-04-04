using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] float accleration = 20f;  //����/���� ���ӵ�
    [SerializeField] float steering = 10f;    //����ӵ�
    [SerializeField] float maxSpeed = 100f;   //�ִ� �ӵ� ����
    [SerializeField] float driftFactor = 0.95f; //�������� �� �̲�����

    [SerializeField] float slowAcclerationRatio = 0.5f;
    [SerializeField] float booostAcclerationRatio = 1.5f;

    [SerializeField] ParticleSystem smokeLeft;
    [SerializeField] ParticleSystem smokeRight;
    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;

    Rigidbody2D rb;
    AudioSource audioSource;

    float defaultAcceleration;
    float slowAcceleration;
    float boostAcceleration;

    public object ResestAcceleration { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = rb.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
    }

    private void Update()
    {
        float sidewayVelocity = Vector2.Dot(rb.linearVelocity, transform.right);

        bool isDrifting = rb.linearVelocity.magnitude > 2f && Mathf.Abs(sidewayVelocity) > 1f;
        if (isDrifting)
        {
            if (audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }
        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;


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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            accleration = boostAcceleration;
            Debug.Log("Boost!!!!");

            Invoke(nameof(ResetAcceleration), 5f);
        }
    }
    void ResetAcceleration()
    {
        accleration = defaultAcceleration;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        accleration = slowAcceleration;

        Invoke(nameof(ResetAcceleration), 3f);
    }
}