using UnityEngine;

public class FreezeItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb == null) return;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
