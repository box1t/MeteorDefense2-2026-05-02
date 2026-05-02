using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    public Image image;
    public float flashDuration = 0.2f;

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        Color c = image.color;
        c.a = 0.5f; // яркость вспышки
        image.color = c;

        yield return new WaitForSeconds(flashDuration);

        c.a = 0f;
        image.color = c;
    }
}
