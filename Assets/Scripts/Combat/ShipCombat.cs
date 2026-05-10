using UnityEngine;

public class ShipCombat : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectilePrefab;

    [Header("Fire")]
    public Transform firePoint;

    [Header("Aim")]
    public float assistRadius = 10f;

    int meteorMask;

    void Start()
    {
        meteorMask = LayerMask.GetMask("Meteor");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

	void Fire()
	{
		Transform target =
		    FindClosestMeteor();

		if (target == null)
		    return;

		GameObject projectile =
		    Instantiate(
		        projectilePrefab,
		        firePoint.position,
		        Quaternion.identity
		    );

		Projectile p =
		    projectile.GetComponent<Projectile>();

		p.target = target;
	}
	
	Transform FindClosestMeteor()
	{
		GameObject[] meteors =
		    GameObject.FindGameObjectsWithTag("Enemy");

		Transform bestTarget = null;

		float bestDistance = Mathf.Infinity;

		foreach (GameObject meteor in meteors)
		{
		    float distance =
		        Vector3.Distance(
		            transform.position,
		            meteor.transform.position
		        );

		    if (distance < bestDistance)
		    {
		        bestDistance = distance;
		        bestTarget = meteor.transform;
		    }
		}

		return bestTarget;
	}

    Transform FindBestTarget()
    {
        Camera cam = Camera.main;

        if (cam == null)
            return null;

        Vector3 center =
            cam.transform.position +
            cam.transform.forward * 20f;

        Collider[] hits =
            Physics.OverlapSphere(
                center,
                assistRadius,
                meteorMask
            );

        float bestDot = 0.7f;

        Transform bestTarget = null;

        foreach (Collider col in hits)
        {
            Vector3 dir =
                (
                    col.transform.position -
                    cam.transform.position
                ).normalized;

            float dot =
                Vector3.Dot(
                    cam.transform.forward,
                    dir
                );

            if (dot > bestDot)
            {
                bestDot = dot;
                bestTarget = col.transform;
            }
        }

        return bestTarget;
    }
}
