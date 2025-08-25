using TMPro;
using UnityEngine;

public class Milepost : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled == false) return;
        enabled = false;

        ProgressControl.Instance.SetProgress(transform.position.y);
        GetComponent<Collider2D>().enabled = false;
    }
}
