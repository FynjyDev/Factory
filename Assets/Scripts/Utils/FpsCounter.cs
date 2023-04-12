using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public int AverageFPS { get; private set; }

    public string Title;
    public TMP_Text TextFps;

    private string[] stringsFromFps;

    private int frameRange = 60;

    private int[] fpsBuffer;
    private int fpsBufferIndex;
    private int maxFps;

    private void Start()
    {
        if (fpsBuffer == null || frameRange != fpsBuffer.Length)
            InitializeBuffer();

        stringsFromFps = new string[1000];
        for (int i = 0; i < stringsFromFps.Length; i++)
            stringsFromFps[i] = i.ToString();

        maxFps = stringsFromFps.Length - 1;
    }

    private void Update()
    {
        UpdateBuffer();
        CalculateFps();

        TextFps.text = $"{Title}\n{stringsFromFps[Mathf.Clamp(AverageFPS, 0, maxFps)]}";
    }

    private void InitializeBuffer()
    {
        if (frameRange <= 0) frameRange = 1;

        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex] = (int)(1f / Time.unscaledDeltaTime);

        fpsBufferIndex++;

        if (fpsBufferIndex >= frameRange) fpsBufferIndex = 0;
    }

    private void CalculateFps()
    {
        int _sum = 0;

        for (int i = 0; i < frameRange; i++)
        {
            int _fps = fpsBuffer[i];
            _sum += _fps;
        }

        AverageFPS = _sum / frameRange;
    }
}