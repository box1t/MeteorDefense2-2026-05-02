using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
