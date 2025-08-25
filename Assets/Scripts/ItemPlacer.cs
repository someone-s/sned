using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] private PointerEvent pointerEvent;
    [SerializeField] private ItemSpawner itemSpawner;

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
        target.GetComponent<Rigidbody2D>().simulated = true;
    }
}
