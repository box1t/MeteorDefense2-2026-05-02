using UnityEngine;
using System.Collections.Generic;

public class MeteorCache : MonoBehaviour
{
    List<GameObject> cached = new List<GameObject>();

    void Update()
    {
        // Удалить (Q)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Meteor meteor = hit.collider.GetComponent<Meteor>();

                if (meteor != null)
                {
                    cached.Add(meteor.gameObject);
                    meteor.gameObject.SetActive(false);
                    meteor.spawner.MeteorDestroyed();
                }
            }
        }

        // Вернуть (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cached.Count > 0)
            {
                GameObject obj = cached[cached.Count - 1];
                cached.RemoveAt(cached.Count - 1);

                obj.SetActive(true);

                // вернуть рядом с игроком
                obj.transform.position = new Vector3(
                    Random.Range(-3f, 3f),
                    3f,
                    0f
                );
            }
        }
    }
}
