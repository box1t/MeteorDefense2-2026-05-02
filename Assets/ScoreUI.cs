using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        if (GameManager.Instance == null) return;

        text.text = "Destroyed: " + GameManager.Instance.destroyedMeteors;
    }
}
