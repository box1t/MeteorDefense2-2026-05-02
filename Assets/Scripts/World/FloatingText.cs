using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Lifetime")]
    public float lifeTime = 1.5f;

    TextMeshProUGUI textMesh;

    Color startColor;

    float timer;

    void Start()
    {
        textMesh =
            GetComponent<TextMeshProUGUI>();

        startColor = textMesh.color;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // движение вверх
        transform.position +=
            Vector3.up *
            moveSpeed *
            Time.deltaTime;

        // fade
        float alpha =
            Mathf.Lerp(
                1f,
                0f,
                timer / lifeTime
            );

        Color c = startColor;

        c.a = alpha;

        textMesh.color = c;

        // destroy
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
