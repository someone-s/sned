using UnityEngine;

public class CameraFit : MonoBehaviour
{
    [SerializeField] private float mult;

    [SerializeField] private float offset;

    private void Awake()
    {
        float ratio = (float)Display.main.systemHeight / Display.main.systemWidth;
        Camera.main.orthographicSize = ratio * mult;
        Camera.main.transform.position = new Vector3(0f, ratio * mult + offset, -10f);
        Debug.Log($"{ratio} {Camera.main.orthographicSize}");
    }
}
