using UnityEngine;

public class LockOnSystem : MonoBehaviour
{
    public float lockRadius = 50f;

    public Transform currentTarget;

    void Update()
    {
        FindNearestTarget();
    }

    void FindNearestTarget()
    {
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;

        Transform bestTarget = null;

        foreach (GameObject enemy in enemies)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    enemy.transform.position
                );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                bestTarget = enemy.transform;
            }
        }

        currentTarget = bestTarget;
    }
}
