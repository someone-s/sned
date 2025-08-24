using Sirenix.OdinInspector;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    private Vector3 targetPosition;
    public Vector3 TargetPosition
    {
        get => targetPosition;
        set
        {
            targetPosition = value;
            enabled = true;
        }
    }
    public Vector3 Position
    {
        get => transform.localPosition;
        set
        {
            transform.localPosition = value;
            TargetPosition = value;
        } 
    }
    [SerializeField] private AnimationCurve speedCurve;

    private void Awake()
    {
        targetPosition = transform.localPosition;
    }

    [Button]
    public void SetTargetPosition(Vector3 target) => TargetPosition = target;

    private void Update()
    {
        Vector3 difference = targetPosition - transform.localPosition;
        Vector3 change = new(
            Mathf.Sign(difference.x) * speedCurve.Evaluate(Mathf.Abs(difference.x)),
            Mathf.Sign(difference.y) * speedCurve.Evaluate(Mathf.Abs(difference.y)),
            Mathf.Sign(difference.z) * speedCurve.Evaluate(Mathf.Abs(difference.z)));
        change *= Time.deltaTime;
        transform.localPosition += change;

        if (Vector3.Distance(targetPosition, transform.localPosition) < 0.01f)
        {
            transform.localPosition = targetPosition;
            enabled = false;
        }
    }
}
