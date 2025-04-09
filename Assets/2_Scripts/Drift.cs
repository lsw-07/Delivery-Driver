using UnityEngine;

public class Drift : MonoBehaviour
{
    [Header("전진/후진 가속도")] public float acceleration = 10f;
    [Header("조향 속도")] public float steering = 3f;
    [Header("낮을수록 더 미끄러짐")] public float driftFactor = 0.95f;
    [Header("최대 속도 제한")] public float maxSpeed = 1000f;

    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;
    public float driftThreshold = 1.5f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public TrailRenderer leftTrail;
    public TrailRenderer rightTrail;

    private bool isBraking = false;
    private bool isStoppedByBrake = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        isBraking = Input.GetKey(KeyCode.Space);

        if (isBraking)
        {
            ApplyBrake();
        }
        else
        {
            if (isStoppedByBrake)
            {
                // 브레이크로 멈췄으면 스페이스바 뗄 때까지 대기
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
                rb.MoveRotation(rb.rotation - turnAmount);
            }
        }

        ApplyDrift();
    }

    void ApplyBrake()
    {
        float brakeForce = 0.05f; // 감속 계수
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
        // 브레이크 중일 때 드리프트 더 강하게
        float currentDriftFactor = isBraking ? driftFactor * 0.85f : driftFactor;

        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * currentDriftFactor;
    }

    void Update()
    {
        float sidewaysVelocity = Vector2.Dot(rb.linearVelocity, transform.right);
        bool isDrifting = Mathf.Abs(sidewaysVelocity) > driftThreshold && rb.linearVelocity.magnitude > 2f;

        if (isDrifting || isBraking)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();

            // 브레이크 시 파티클 강화
            var emissionLeft = smokeLeft.emission;
            var emissionRight = smokeRight.emission;
            emissionLeft.rateOverTime = isBraking ? 50f : 20f;
            emissionRight.rateOverTime = isBraking ? 50f : 20f;
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, isDrifting || isBraking ? 1f : 0f, Time.deltaTime * 5f);
        leftTrail.emitting = isDrifting || isBraking;
        rightTrail.emitting = isDrifting || isBraking;
    }
}
