using UnityEngine;

public class FrameRateSettings : SingletonMonoBehaviour<FrameRateSettings>
{
    // NOTE:
    // vSyncCount = 0 means don't sync.
    // vSyncCount = 1 means every V blank.
    // When set 2 in 60Hz, it becomes 60/2 = 30 frame/sec.

    // NOTE:
    // targetFrameRate = -1(default) is special value to fit every platform.
    // For example, when in mobile platform, frame rate will be set 30fps.

    public bool warningInEditor = false;

    [SerializeField, Range( 0,    4)] private int vSyncCount = 1;
    [SerializeField, Range(-1, 9999)] private int frameRate  = -1;

    public int VSyncCount
    {
        get => vSyncCount;
        set { vSyncCount = value; UpdateSettings(); }
    }

    public int FrameRate
    {
        get => frameRate;
        set { frameRate = value; UpdateSettings(); }
    }

    protected override void Awake()
    {
        base.Awake();
        UpdateSettings();
    }

    private void OnValidate()
    {
        UpdateSettings();
    }

    private void ValidateParameters()
    {
        vSyncCount = Mathf.Max( 0, Mathf.Min(   4, vSyncCount));
        frameRate  = Mathf.Max(-1, Mathf.Min(9999, frameRate));
    }

    private void UpdateSettings()
    {
        ValidateParameters();

        QualitySettings.vSyncCount  = vSyncCount;
        Application.targetFrameRate = frameRate;

        if (warningInEditor && Application.isEditor)
        {
            Debug.Log("Application.targetFrameRate setting is ignored in Editor.", this);
        }
    }
}