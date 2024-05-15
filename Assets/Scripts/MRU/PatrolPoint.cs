using TMPro;
using UnityEngine;
public class PatrolPoint : MonoBehaviour
{
    [SerializeField] private float timeToNextPoint;
    [SerializeField] private TMP_Text timeText;

    void Start()
    {
        timeText.text = "Tiempo al siguiente punto: " + timeToNextPoint.ToString() + "s";
    }

    public float GetTimeToNextPoint()
    {
        return timeToNextPoint;
    }
}
