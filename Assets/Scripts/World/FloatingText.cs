using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 1f;

    TextMeshProUGUI text;
    Color color;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        color = text.color;

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // движение вверх
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // плавное исчезновение
        color.a -= Time.deltaTime / lifetime;
        text.color = color;
    }
}
