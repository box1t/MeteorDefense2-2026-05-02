using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}
