using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker Instance { get; private set; }

    private ScoreTracker()
    {
        Instance = this;
    }

    [SerializeField] private GameObject endPanel;
    [SerializeField] private TMP_Text reasonTextArea;
    [SerializeField] private TMP_Text scoreTextArea;
    [SerializeField] private TMP_Text itemTextArea;
    [SerializeField] private TMP_Text heightTextArea;

    [SerializeField] private GameObject inputToDisable;
    [SerializeField] private float itemHeight;

    private int itemCount = 0;
    private float height = 0f;

    public void IncrementItemCounter()
    {
        itemCount++;
    }

    public void SetHeight(float newHeight)
    {
        height = (newHeight + itemHeight * 0.5f) / itemHeight * 0.5f;
    }

    public void ComputeResult()
    {
        CountdownTimer.Instance.Hide();
        HintDetect.Instance.Block();

        inputToDisable.SetActive(false);
        
        scoreTextArea.text = Mathf.CeilToInt(height * itemCount).ToString();
        itemTextArea.text = itemCount.ToString();
        heightTextArea.text = height.ToString("0.0");

        endPanel.SetActive(true);
    }

    public void OnDangerZoneEntered()
    {
        reasonTextArea.text = "Item fell into the danger zone";
        ComputeResult();
    }

    public void OnCountdownTimeout()
    {
        reasonTextArea.text = "Ran out of time";
        ComputeResult();
    }
}
