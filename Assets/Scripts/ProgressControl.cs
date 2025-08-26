using System;
using UnityEngine;

public class ProgressControl : MonoBehaviour
{
    public static ProgressControl Instance { get; private set; }
    [SerializeField] private VerticalMove verticalMove;
    [SerializeField] private float progress;

    private ProgressControl()
    {
        Instance = this;
    }

    public void SetProgress(float newProgress)
    {
        if (newProgress < progress) return;
        enabled = true;
        verticalMove.Move(newProgress - progress);
        progress = newProgress;

        SoundPlayer.Instance.PlayEffect(1);
        ScoreTracker.Instance.SetHeight(progress);
    }
}