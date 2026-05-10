using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health = 3;

	public GameObject explosionPrefab;

	void Die()
	{
		if (explosionPrefab != null)
		{
		    Instantiate(
		        explosionPrefab,
		        transform.position,
		        Quaternion.identity
		    );
		}

		Destroy(gameObject);
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
}
