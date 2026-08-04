using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text shotsText;
    [SerializeField] private TMP_Text holeText;

    [SerializeField] private GameObject restartButton;

    private void Awake()
    {
        panel.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);
    }

    public void ShowHoleResult(int hole, int shotsTaken, int par)
    {
        panel.SetActive(true);

        // Hide restart button until the last hole
        if (restartButton != null)
            restartButton.SetActive(false);

        holeText.text = "Hole " + hole + " Complete";
        shotsText.text = "Shots : " + shotsTaken;

        if (shotsTaken == 1)
        {
            resultText.text = "HOLE IN ONE!";
            return;
        }

        int difference = shotsTaken - par;

        switch (difference)
        {
            case -3:
                resultText.text = "ALBATROSS!";
                break;

            case -2:
                resultText.text = "EAGLE!";
                break;

            case -1:
                resultText.text = "BIRDIE!";
                break;

            case 0:
                resultText.text = "PAR!";
                break;

            case 1:
                resultText.text = "BOGEY!";
                break;

            case 2:
                resultText.text = "DOUBLE BOGEY!";
                break;

            default:
                if (difference > 2)
                    resultText.text = "TRIPLE BOGEY+";
                else
                    resultText.text = "GREAT SHOT!";
                break;
        }
    }

    public void ShowCourseComplete()
    {
        panel.SetActive(true);

        holeText.text = "Course Complete!";
        shotsText.text = "";
        resultText.text = "CONGRATULATIONS!";

        // Show restart button only after the final hole
        if (restartButton != null)
            restartButton.SetActive(true);
    }

    public void HideResult()
    {
        panel.SetActive(false);
    }
}