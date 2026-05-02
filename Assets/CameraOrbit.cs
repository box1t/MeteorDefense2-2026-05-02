using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // корабль

    public float distance = 10f;
    public float rotationSpeed = 3f;
    public float zoomSpeed = 5f;

    float yaw = 0f;
    float pitch = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        // 🔥 Вращение мышью
        if (Input.GetMouseButton(1)) // ПКМ
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * 100f * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * 100f * Time.deltaTime;
        }

        // 🔒 Ограничение угла (чтобы не переворачивалось)
        pitch = Mathf.Clamp(pitch, -20f, 80f);

        // 🔍 Зум колесиком
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, 5f, 25f);

        // 📍 Позиция камеры
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        transform.position = position;
        transform.LookAt(target);
    }
}
