using UnityEngine;

public class HintShow : MonoBehaviour
{

    [SerializeField] private RectTransform visualObject;

    [SerializeField] private AnimationCurve visualPath;
    private float elpasedTime = 0f;

    private void Update()
    {
        elpasedTime += Time.deltaTime;
        visualObject.anchoredPosition = new Vector2(0f, visualPath.Evaluate(elpasedTime));
    }
}
