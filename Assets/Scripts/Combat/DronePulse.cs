using UnityEngine;

public class DronePulse : MonoBehaviour
{
    [Header("Pulse")]
    public float pulseRadius = 10f;

    public float force = 30f;

    [Header("Cooldown")]
    public float cooldown = 3f;

    float timer;

    [Header("VFX")]
    public ParticleSystem pulseVFX;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (timer >= cooldown)
            {
                Pulse();

                timer = 0f;
            }
        }
    }

    void Pulse()
    {
        // VFX
        if (pulseVFX != null)
        {
            pulseVFX.Play();
        }

        // push meteors
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                pulseRadius
            );

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Rigidbody rb =
                    hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 dir =
                        (
                            hit.transform.position -
                            transform.position
                        ).normalized;

                    rb.AddForce(
                        dir * force,
                        ForceMode.Impulse
                    );
                }
            }
        }
    }
}
