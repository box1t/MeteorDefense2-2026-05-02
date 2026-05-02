using TMPro;
using UnityEngine;
using System.Collections;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        text.text = "Капитан, впереди метеоритное поле...";
        yield return new WaitForSeconds(10);



        text.text = "";
    }
}
