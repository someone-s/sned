using TMPro;
using UnityEngine;

public class Miletext : MonoBehaviour
{
    [SerializeField] private float itemHeight;

    private void Start()
    {
        GetComponentInChildren<TMP_Text>().text = ((transform.position.y + itemHeight * 0.5f) / itemHeight * 0.5f).ToString("0.0");
    }
}
