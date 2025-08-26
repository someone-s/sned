using UnityEngine;

public class DetectFail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTracker.Instance.OnDangerZoneEntered();
    }
}
