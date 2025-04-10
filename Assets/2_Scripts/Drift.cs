using UnityEngine;

public class Drift : MonoBehaviour
{
    [Header("전진/후진 가속도")] public float acceleration = 85f;
    [Header("조향 속도")] public float steering = 5f;
    [Header("낮을수록 더 미끄러짐")] public float driftFactor = 0.85f;
    [Header("최대 속도 제한")] public float maxSpeed = 500f;

    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;
    public float driftThreshold = 1.5f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public TrailRenderer leftTrail;
    public TrailRenderer rightTrail;

    private bool isBraking = false;
    private bool isStoppedByBrake = false;

    private bool isDriftMode = false; // 드리프트 모드 추가

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        isBraking = Input.GetKey(KeyCode.Space);
        isDriftMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); // Shift 키 드리프트 모드

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
                    turnAmount *= 2f; // 드리프트 모드 시 조향 강화
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
            currentDriftFactor *= 0.8f; // 드리프트 모드 시 더 미끄러지게
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
