using UnityEngine;

[ExecuteInEditMode]
public class CameraFit : MonoBehaviour
{
    [SerializeField] private float mult;
    private void Awake()
    {
        Display.onDisplaysUpdated += Refresh;
    }

    private void Refresh()
    {
            float ratio = (float)Display.main.systemHeight / Display.main.systemWidth;
            Camera.main.orthographicSize = ratio * mult;
            Debug.Log($"{ratio} {Camera.main.orthographicSize}");
    }

    private void OnDestroy()
    {
        Display.onDisplaysUpdated -= Refresh;
    }
}
