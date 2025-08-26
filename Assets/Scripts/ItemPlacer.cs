using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] private PointerEvent pointerEvent;
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private CountdownTimer countdownTimer;

    private void Awake()
    {
        pointerEvent.onPointerDown.AddListener(Attach);
        pointerEvent.onPointerUp.AddListener(Detach);
    }

    private void Attach(PointerEventData _)
    {
        GameObject target = itemSpawner.First;
        target.transform.parent = null;
        target.GetComponent<FollowMove>().enabled = true;
        target.GetComponent<SmoothScale>().SetTargetScale(Vector3.one * 20f);
    }

    private void Detach(PointerEventData _)
    {
        GameObject target = itemSpawner.First;
        itemSpawner.Shift();

        target.GetComponent<FollowMove>().enabled = false;
        target.GetComponent<SmoothMove>().enabled = false;
        target.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Middleground");
        if (target.TryGetComponent(out Rigidbody2D rigidbody2D))
            rigidbody2D.simulated = true;

        countdownTimer.Reset();

        SoundPlayer.Instance.PlayEffect(0);
        ScoreTracker.Instance.IncrementItemCounter();
    }
}
