using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance { get; private set; }
    private CountdownTimer()
    {
        Instance = this;
    }

    public float duration;

    private float remaining;

    [SerializeField] private TMP_Text textArea; 

    private void Start() => Reset();
    public void Reset()
    {
        remaining = duration;
        enabled = true;
    }

    public void Hide()
    {
        textArea.gameObject.SetActive(false);
        enabled = false;
    }

    private void Update()
    {
        remaining -= Time.deltaTime;
        if (remaining <= 0f)
        {
            remaining = 0f;
            enabled = false;
            ScoreTracker.Instance.OnCountdownTimeout();
        }
        textArea.text = remaining.ToString("0.0");
    }
}
