using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log("Ship HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            DestroyShip();
        }
    }

    void DestroyShip()
    {
        Debug.Log("SHIP DESTROYED");
    }
}
