using UnityEngine;

public class StartUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject scoreUI;      // Drag the "Score" object here
    [SerializeField] private GameObject resultPanel;

    private void Start()
    {
        startPanel.SetActive(true);

        if (scoreUI != null)
            scoreUI.SetActive(false);

        if (resultPanel != null)
            resultPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

        if (scoreUI != null)
            scoreUI.SetActive(true);

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}