using TMPro;
using UnityEngine;

public class Milepost : MonoBehaviour
{
    [SerializeField] private float itemHeight;

    private void Start()
    {
        GetComponentInChildren<TMP_Text>().text = ((transform.position.y + itemHeight * 0.5f) / itemHeight * 0.5f).ToString("0.0");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled == false) return;
        enabled = false;

        SpeedControl.Instance.SetProgress(transform.position.y);
        GetComponent<Collider2D>().enabled = false;
    }
}
