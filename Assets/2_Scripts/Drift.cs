using UnityEngine;

public class Drift : MonoBehaviour
{
    [Header("전진/후진 가속도")] public float acceleration = 20f;
    [Header("조향 속도")] public float steering = 3f;
    [Header("낮을수록 더 미끄러짐")] public float driftFactor = 0.95f;
    [Header("최대 속고 제한")] public float maxSpeed = 10f;


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

    private void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration);
        }

        //float turnAmount = Input.GetAxis("Hor izontal") * steering * speed * Time.fixedDeltaTime;
        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

        ApplyDrift();
        Vector2 forvardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.right);


    }
    void ApplyDrift()
    {
        Vector2 forvardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forvardVelocity + sideVelocity * driftFactor;
    }

    private void Update()
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
            if (audioSource.isPlaying) audioSource.Play();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, isDrifting ? 1f : 0f, Time.deltaTime * 5f);
        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;
    }
}
