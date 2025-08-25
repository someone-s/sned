using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMove : MonoBehaviour
{
    private SmoothMove smoothMove;

    [SerializeField] private Vector2 offset;

    private void Awake()
    {
        smoothMove = GetComponent<SmoothMove>();
    }

    private void Update()
    {
        smoothMove.TargetPosition = (Vector2)Camera.main.ScreenToWorldPoint(Pointer.current.position.value) + offset;
    }
}
