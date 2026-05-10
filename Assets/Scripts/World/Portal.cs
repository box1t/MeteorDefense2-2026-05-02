using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Transform target;

    void OnTriggerEnter(Collider other)
    {
        Meteor meteor = other.GetComponent<Meteor>();

        if (meteor != null && !meteor.isTeleporting)
        {
            StartCoroutine(Teleport(meteor));
        }
    }

    IEnumerator Teleport(Meteor meteor)
    {
        meteor.isTeleporting = true;

        Rigidbody rb = meteor.GetComponent<Rigidbody>();

        // переносим
        meteor.transform.position = target.position + target.forward * 2f;

        // толчок вперёд
        rb.linearVelocity = target.forward * 5f;

        yield return new WaitForSeconds(0.5f);

        meteor.isTeleporting = false;
    }
}
