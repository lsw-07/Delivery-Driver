using UnityEngine;
/*

public class Drift : MonoBehaviour
{
    [Header("����/���� ���ӵ�")] public float acceleration = 1000f;
    [Header("���� �ӵ�")] public float steering = 3f;
    [Header("�������� �� �̲�����")] public float driftFactor = 0.95f;
    [Header("�ִ� �Ӱ� ����")] public float maxSpeed = 1000f;

    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;

    public float driftThreshold = 1.5f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public TrailRenderer leftTrail;
    public TrailRenderer rightTrail;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (Mathf.Abs(speed) < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration);
        }
        
        //float turnAmount = lnput.GetAxis("Hor izontal") * steering * speed * TIme.fixeDeltaTIme;
        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

        ApplyDrift();
    }
    void ApplyDrift()
    {
        Vector2 forvardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forvardVelocity + sideVelocity * driftFactor;
    }

    void Update()
    {
        float sidevaysVelocity = Vector2.Dot(rb.linearVelocity, transform.right);

        bool isDrifting = Mathf.Abs(sidevaysVelocity) > driftThreshold && rb.linearVelocity.magnitude > 2f;

        if (isDrifting)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Play();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, isDrifting ? 1f : 0f, Time.deltaTime * 5f);
        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;
    }

}
using UnityEngine;

public class Drift : MonoBehaviour
{
    [Header("���� ���ӵ�")] public float forwardAcceleration = 1000f;
    [Header("���� ���ӵ�")] public float reverseAcceleration = 100f;
    [Header("���� �ӵ�")] public float steering = 3f;
    [Header("�������� �� �̲�����")] public float driftFactor = 0.95f;
    [Header("�ִ� �ӵ� ����")] public float maxSpeed = 1000f;

    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;

    public float driftThreshold = 1.5f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public TrailRenderer leftTrail;
    public TrailRenderer rightTrail;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        float verticalInput = Input.GetAxis("Vertical");

        // ����/���� ���� ����
        if (speed < maxSpeed && verticalInput != 0f)
        {
            float accleeration = 0;
            // float acceleration = verticalInput > 0 ? forwardAcceleration : reverseAcceleration;
            if (verticalInput > 0)
            {
                accleeration = forwardAcceleration;

            }
            else if (verticalInput < 0)
            {
                accleeration = reverseAcceleration;
            }
            rb.AddForce(transform.up * verticalInput * accleeration);
        }

        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);


        // �����̽��� ���� (�� ������ �����ϵ��� ����)
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity *= 0.9f; // ���� ���� �� ũ�� �ؼ� ���� ��� ����

            ApplyDrift();
        }
    }

    void ApplyDrift()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * driftFactor;
    }

    void Update()
    {
        float sidewaysVelocity = Vector2.Dot(rb.linearVelocity, transform.right);

        bool isDrifting = Mathf.Abs(sidewaysVelocity) > driftThreshold && rb.linearVelocity.magnitude > 2f;

        if (isDrifting)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop(); // ����: Stop ���� ����
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, isDrifting ? 1f : 0f, Time.deltaTime * 5f);
        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;
    }
}


using UnityEngine;

public class Drift : MonoBehaviour
{
    [Header("����/���� ���ӵ�")] public float acceleration = 85f;
    [Header("���� �ӵ�")] public float steering = 5f;
    [Header("�������� �� �̲�����")] public float driftFactor = 0.85f;
    [Header("�ִ� �ӵ� ����")] public float maxSpeed = 500f;

    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;
    public float driftThreshold = 1.5f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public TrailRenderer leftTrail;
    public TrailRenderer rightTrail;

    private bool isBraking = false;
    private bool isStoppedByBrake = false;

    private bool isDriftMode = false; // �帮��Ʈ ��� �߰�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        isBraking = Input.GetKey(KeyCode.Space);
        isDriftMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); // Shift Ű �帮��Ʈ ���

        if (isBraking)
        {
            ApplyBrake();
        }
        else
        {
            if (isStoppedByBrake)
            {
                if (!Input.GetKey(KeyCode.Space))
                {
                    isStoppedByBrake = false;
                }
            }
            else
            {
                float speed = Vector2.Dot(rb.linearVelocity, transform.up);
                if (Mathf.Abs(speed) < maxSpeed)
                {
                    rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration);
                }

                float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);

                if (isDriftMode)
                {
                    turnAmount *= 2f; // �帮��Ʈ ��� �� ���� ��ȭ
                }

                rb.MoveRotation(rb.rotation - turnAmount);
            }
        }

        ApplyDrift();
    }

    void ApplyBrake()
    {
        float brakeForce = 0.05f;
        Vector2 brakeVelocity = rb.linearVelocity * brakeForce;

        rb.linearVelocity -= brakeVelocity;

        if (rb.linearVelocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
            isStoppedByBrake = true;
        }
    }

    void ApplyDrift()
    {
        float currentDriftFactor = driftFactor;

        if (isBraking)
        {
            currentDriftFactor *= 0.85f;
        }

        if (isDriftMode)
        {
            currentDriftFactor *= 0.8f; // �帮��Ʈ ��� �� �� �̲�������
        }

        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * currentDriftFactor;
    }

    void Update()
    {
        float sidewaysVelocity = Vector2.Dot(rb.linearVelocity, transform.right);
        bool isDrifting = Mathf.Abs(sidewaysVelocity) > driftThreshold && rb.linearVelocity.magnitude > 2f;

        if (isDrifting || isBraking || isDriftMode)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();

            var emissionLeft = smokeLeft.emission;
            var emissionRight = smokeRight.emission;
            emissionLeft.rateOverTime = isBraking || isDriftMode ? 50f : 20f;
            emissionRight.rateOverTime = isBraking || isDriftMode ? 50f : 20f;
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, isDrifting || isBraking || isDriftMode ? 1f : 0f, Time.deltaTime * 5f);
        leftTrail.emitting = isDrifting || isBraking || isDriftMode;
        rightTrail.emitting = isDrifting || isBraking || isDriftMode;
    }
}


*/
