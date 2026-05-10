using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float range = 100f;

    // помощь прицелу
    public float assistRadius = 2.5f;

    // слой метеоров
    int meteorMask;

    void Start()
    {
        meteorMask = LayerMask.GetMask("Meteor");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Camera.main == null) return;

        Camera cam = Camera.main;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // =========================
        // 🎯 1. ТОЧНЫЙ ВЫСТРЕЛ
        // =========================
        if (Physics.Raycast(ray, out hit, range, meteorMask))
        {
            Meteor meteor = hit.collider.GetComponentInParent<Meteor>();
            if (meteor != null)
            {
                meteor.DestroyMeteor();
                return;
            }
        }

        // =========================
        // 💥 2. ПОМОЩЬ ПРИЦЕЛУ
        // =========================
        Vector3 center = cam.transform.position + cam.transform.forward * 10f;

        Collider[] hits = Physics.OverlapSphere(center, assistRadius, meteorMask);

        float bestDot = 0.8f; // насколько "смотрим" в цель
        Meteor bestTarget = null;

        foreach (var col in hits)
        {
            Vector3 dir = (col.transform.position - cam.transform.position).normalized;
            float dot = Vector3.Dot(cam.transform.forward, dir);

            if (dot > bestDot)
            {
                bestDot = dot;
                bestTarget = col.GetComponentInParent<Meteor>();
            }
        }

        if (bestTarget != null)
        {
            bestTarget.DestroyMeteor();
        }
    }
}
