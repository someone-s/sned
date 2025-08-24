using Sirenix.OdinInspector;
using UnityEngine;

public class SmoothScale : MonoBehaviour
{
    public Vector3 Scale
    {
        get => transform.localScale;
        set
        {
            transform.localScale = value;
            TargetScale = value;
        }
    }

    private Vector3 targetScale;
    public Vector3 TargetScale
    {
        get => targetScale;
        set
        {
            targetScale = value;
            enabled = true;
        }
    }
    [SerializeField] private AnimationCurve speedCurve;

    private void Awake()
    {
        targetScale = transform.localScale;
    }

    [Button]
    public void SetTargetScale(Vector3 target) => TargetScale = target;

    private void Update()
    {
        Vector3 difference = targetScale - transform.localScale;
        Vector3 change = new(
            Mathf.Sign(difference.x) * speedCurve.Evaluate(Mathf.Abs(difference.x)),
            Mathf.Sign(difference.y) * speedCurve.Evaluate(Mathf.Abs(difference.y)),
            Mathf.Sign(difference.z) * speedCurve.Evaluate(Mathf.Abs(difference.z)));
        change *= Time.deltaTime;
        transform.localScale += change;

        if (Vector3.Distance(targetScale, transform.localScale) < 0.01f)
        {
            transform.localScale = targetScale;
            enabled = false;
        }
    }
}
