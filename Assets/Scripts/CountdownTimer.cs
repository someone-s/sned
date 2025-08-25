using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public float duration;

    private float remaining;

    [SerializeField] private TMP_Text textArea; 
    public UnityEvent OnTimeout;

    private void Start() => Reset();
    public void Reset()
    {
        remaining = duration;
        enabled = true;
    }

    private void Update()
    {
        remaining -= Time.deltaTime;
        if (remaining <= 0f)
        {
            remaining = 0f;
            OnTimeout.Invoke();
            enabled = false;
        }
        textArea.text = remaining.ToString("0.0");
    }
}
