using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public int AverageFPS { get; private set; }

    public string title;
    public TMP_Text TextFps;

    private string[] _stringsFromFps;

    private int _frameRange = 60;

    private int[] _fpsBuffer;
    private int _fpsBufferIndex;
    private int _maxFps;

    private void Start()
    {
        if (_fpsBuffer == null || _frameRange != _fpsBuffer.Length)
            InitializeBuffer();

        _stringsFromFps = new string[1000];
        for (int i = 0; i < _stringsFromFps.Length; i++)
            _stringsFromFps[i] = i.ToString();

        _maxFps = _stringsFromFps.Length - 1;
    }

    private void Update()
    {
        UpdateBuffer();
        CalculateFps();

        TextFps.text = $"{title}\n{_stringsFromFps[Mathf.Clamp(AverageFPS, 0, _maxFps)]}";
    }

    private void InitializeBuffer()
    {
        if (_frameRange <= 0) _frameRange = 1;

        _fpsBuffer = new int[_frameRange];
        _fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        _fpsBuffer[_fpsBufferIndex] = (int)(1f / Time.unscaledDeltaTime);

        _fpsBufferIndex++;

        if (_fpsBufferIndex >= _frameRange) _fpsBufferIndex = 0;
    }

    private void CalculateFps()
    {
        int sum = 0;

        for (int i = 0; i < _frameRange; i++)
        {
            int fps = _fpsBuffer[i];
            sum += fps;
        }

        AverageFPS = sum / _frameRange;
    }
}