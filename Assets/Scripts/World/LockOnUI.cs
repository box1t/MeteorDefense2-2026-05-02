using UnityEngine;

public class LockOnUI : MonoBehaviour
{
    public LockOnSystem lockOn;

    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (lockOn.currentTarget == null)
        {
            gameObject.SetActive(false);

            return;
        }

        gameObject.SetActive(true);

        Vector3 screenPos =
            Camera.main.WorldToScreenPoint(
                lockOn.currentTarget.position
            );

        rect.position = screenPos;
        
    }
    
}
