using System.Collections;
using TMPro;
using UnityEngine;

public class Milepost : MonoBehaviour
{
    public IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (enabled == false) yield break;
        enabled = false;

        yield return new WaitForSeconds(3f);

        if (!collider.IsTouching(GetComponent<Collider2D>())) yield break;

        ProgressControl.Instance.SetProgress(transform.position.y);
        GetComponent<Collider2D>().enabled = false;
    }
}
