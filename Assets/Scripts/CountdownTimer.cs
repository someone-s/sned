using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public float duration;

    private float remaining;

    public UnityEvent OnTimeout;

    private void Start() => Reset();
    public void Reset()
    {
        remaining = duration;
    }

    private void Update()
    {
        remaining -= Time.deltaTime;
        if (remaining <= 0f)
        {
            OnTimeout.Invoke();
        }
    }
}
