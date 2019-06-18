using UnityEngine;

public class FrameRateSettings : SingletonMonoBehaviour<FrameRateSettings>
{
    // NOTE:
    // vSyncCount = 0 means don't sync.
    // vSyncCount = 1 means every V blank.
    // When set 2 in 60Hz, it becomes 60/2 = 30 frame/sec.

    [Range(0, 4)]
    public int vSyncCount = 1;

    // NOTE:
    // targetFrameRate = -1(default) is special value to fit every platform.
    // For example, when in mobile platform, frame rate will be set 30fps.

    [Range(-1, 9999)]
    public int targetFrameRate = -1;

    protected override void Awake()
    {
        base.Awake();

        if (CommandLineArgs.GetValueAsInt("-vSyncCount", out int vSyncCount))
        {
            this.vSyncCount = vSyncCount;
        }

        if (CommandLineArgs.GetValueAsInt("-targetFrameRate", out int targetFrameRate))
        {
            this.targetFrameRate = targetFrameRate;
        }

        UpdateSettings();
    }

    public virtual void UpdateSettings()
    {
        QualitySettings.vSyncCount = this.vSyncCount;
        Application.targetFrameRate = this.targetFrameRate;

        if (Application.isEditor)
        {
            Debug.Log("Application.targetFrameRate setting is ignored in Editor.", this);
        }
    }
}