using UnityEngine;

public class WebsiteLink : MonoBehaviour
{
    [SerializeField] private string url;
    public void OpenLink()
    {
        Application.OpenURL(url); 
    }
}

