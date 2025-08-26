using System.Collections;
using TMPro;
using UnityEngine;

public class Milepost : MonoBehaviour
{
    private readonly WaitForSeconds waitForSeconds = new(3f);

    public IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (enabled == false) yield break;

        yield return waitForSeconds;

        if (!collider.IsTouching(GetComponent<Collider2D>())) yield break;

        enabled = false;

        ProgressControl.Instance.SetProgress(transform.position.y);
        GetComponent<Collider2D>().enabled = false;
    }
}
