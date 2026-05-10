using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int level = 1;

    float timer = 0f;
    public float timeToNextLevel = 10f;

    public TextMeshProUGUI storyText;

    MeteorSpawnerPRO spawner;
	public int destroyedMeteors = 0;
	
	public void AddDestroyedMeteor()
	{
		destroyedMeteors++;
	}
	
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawner = FindFirstObjectByType<MeteorSpawnerPRO>();

        if (storyText != null)
            storyText.text = "Капитан, впереди метеоритное поле. Отталкивайте метеориты, не позволяйте им сталкиваться с кораблём.!";
    }

    void Update()
    {
        if (level > 3) return;

        timer += Time.deltaTime;

        if (timer >= timeToNextLevel)
        {
            timer = 0f;
            NextLevel();
        }
    }

    void NextLevel()
    {
        level++;

        if (level > 3)
        {
            if (storyText != null)
                storyText.text = "Метеоритный дождь завершен!\nВам удалось переждать!";

            Time.timeScale = 0f;
            return;
        }

        if (spawner != null)
            spawner.maxMeteors += 5;

        if (storyText != null)
        {
            if (level == 2)
                storyText.text = "Метеоритный поток усиливается!";
            else if (level == 3)
                storyText.text = "Критическая зона!";
        }
    }
}
