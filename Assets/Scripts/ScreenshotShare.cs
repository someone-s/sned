using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenshotShare : MonoBehaviour
{
    private IEnumerator coroutine;

    public void TakeScreenshotShare()
    {
        if (coroutine != null) return;

        coroutine = TakeScreenshotShareRoutine();

        StartCoroutine(coroutine);
    }

    private IEnumerator TakeScreenshotShareRoutine()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        string filePath = Path.Join(Application.temporaryCachePath, "screenshot.png");
        File.WriteAllBytes(filePath, screenshot.EncodeToPNG());

        Destroy(screenshot);

        new NativeShare().AddFile(filePath).Share();

        coroutine = null;
    }
}

