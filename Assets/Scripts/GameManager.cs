using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject introPanel;

    void Start()
    {
        introPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        introPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
