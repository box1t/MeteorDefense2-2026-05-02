using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.7f;   // длительность тряски
    public float magnitude = 0.7f;  // сила

    Vector3 originalPos;
    float currentTime = 0f;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * magnitude;
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0f;
            transform.localPosition = originalPos;
        }
    }

    public void Shake()
    {
        currentTime = duration;
    }
}
