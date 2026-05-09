using UnityEngine;

public class InputController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ПКМ
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Meteor meteor = hit.collider.GetComponent<Meteor>();

                if (meteor != null)
                {
                    Vector3 dir = (meteor.transform.position - transform.position).normalized;
                    meteor.Push(dir);
                }
            }
        }
    }
}
