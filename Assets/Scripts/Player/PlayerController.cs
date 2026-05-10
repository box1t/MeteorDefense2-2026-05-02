using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 15f;

    public float rotationSpeed = 10f;

    Vector3 startPos;

    Camera cam;

    void Start()
    {
        startPos = transform.position;

        cam = Camera.main;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h =
            Input.GetAxisRaw("Horizontal");

        float v =
            Input.GetAxisRaw("Vertical");

        Vector3 input =
            new Vector3(h, 0, v).normalized;

        if (input.magnitude < 0.1f)
            return;

        // направление камеры
        Vector3 camForward =
            cam.transform.forward;

        Vector3 camRight =
            cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        // движение относительно камеры
        Vector3 moveDir =
            camForward * input.z +
            camRight * input.x;

        // движение
        transform.position +=
            moveDir *
            moveSpeed *
            Time.deltaTime;

        // поворот корабля
        Quaternion targetRot =
            Quaternion.LookRotation(moveDir);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}
