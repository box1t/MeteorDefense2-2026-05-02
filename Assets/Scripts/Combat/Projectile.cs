using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 30f;

    public float rotateSpeed = 10f;

    [Header("Combat")]
    public Transform target;

    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

	void Update()
	{
		if (target == null)
		{
		    Destroy(gameObject);
		    return;
		}

		Vector3 dir =
		    (target.position - transform.position)
		    .normalized;

		transform.position +=
		    dir *
		    speed *
		    Time.deltaTime;

		transform.forward = dir;
	}
    void Move()
    {
        if (target != null)
        {
            Vector3 dir =
                (target.position - transform.position)
                .normalized;

            Quaternion lookRot =
                Quaternion.LookRotation(dir);

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    lookRot,
                    rotateSpeed * Time.deltaTime
                );
        }

        transform.position +=
            transform.forward *
            speed *
            Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Meteor meteor =
            other.GetComponent<Meteor>();

        if (meteor != null)
        {
            meteor.DestroyMeteor();

            Destroy(gameObject);
        }
    }
}
