using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMove : MonoBehaviour
{
    private SmoothMove smoothMove;

    private void Awake()
    {
        smoothMove = GetComponent<SmoothMove>();
    }

    private void Update()
    {
        smoothMove.TargetPosition = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
    }
}
