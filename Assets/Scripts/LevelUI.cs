using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        if (GameManager.Instance == null || text == null) return;

        int level = GameManager.Instance.level;

        string levelName = "";

        if (level == 1) levelName = "Лёгкое поле";
        else if (level == 2) levelName = "Усиленный поток";
        else if (level == 3) levelName = "Критическая зона";
        else levelName = "Завершено";

        text.text = "Level " + level + " — " + levelName;
    }
}
