using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float baseSpeed = 10.0f; // базовая скорость

    void Update()
    {
        if (GameManager.Instance == null) return;

        int level = GameManager.Instance.level;

        float speed = baseSpeed + level * 0.05f;

        float current = RenderSettings.skybox.GetFloat("_Rotation");
        RenderSettings.skybox.SetFloat("_Rotation",
            current + speed * Time.deltaTime);
    }
}
