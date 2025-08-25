using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public static SpeedControl Instance { get; private set; }
    [SerializeField] private VerticalMove verticalMove;

    [SerializeField] private AnimationCurve speedCurve;
    private float maxProgress = 0f;

    private SpeedControl()
    {
        Instance = this;
    }

    public void SetProgress(float progress)
    {
        if (progress < maxProgress) return;
        maxProgress = progress;
        verticalMove.speed = speedCurve.Evaluate(progress);
    }
}