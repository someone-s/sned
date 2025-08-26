using UnityEngine;

public class HintDetect : MonoBehaviour
{
    public static HintDetect Instance { get; private set; }

    private HintDetect()
    {
        Instance = this;
    }

    [SerializeField] private float responseDuration;
    [SerializeField] private float responseTime;
    [SerializeField] private GameObject hintObject;

    public void Reset()
    {
        responseTime = 0f;
        enabled = true;
        hintObject.SetActive(false);
    }

    public void Block()
    {
        hintObject.SetActive(false);
        enabled = false;
    }

    public void Update()
    {
        responseTime += Time.deltaTime;

        if (responseTime > responseDuration)
        {
            hintObject.SetActive(true);
            enabled = false;
        }
    }
}