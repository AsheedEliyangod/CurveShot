using TMPro;
using UnityEngine;

public class ShotsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text shotsText;
    [SerializeField] private TMP_Text holeText;

    public void UpdateShots(int shots)
    {
        shotsText.text = "Shots : " + shots;
    }

    public void UpdateHole(int hole)
    {
        if (holeText != null)
            holeText.text = "Hole : " + hole;
    }
}