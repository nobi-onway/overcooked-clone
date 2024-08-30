using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    #region UnityEditor
    [SerializeField] private Image _progress;
    #endregion

    private IProgressTracker _progressTracker;

    private void Start()
    {
        SetProgressValue(0);

        _progressTracker = GetComponentInParent<IProgressTracker>();

        SetUpEvent(_progressTracker);
    }

    private void SetUpEvent(IProgressTracker progressTracker)
    {
        if (progressTracker == null) return;

        progressTracker.OnProgressChange += SetProgressValue;
    }

    private void SetProgressValue(float value)
    {
        _progress.fillAmount = value;
        ShowIf(value > 0);
    }

    private void ShowIf(bool canShow)
    {
        this.transform.gameObject.SetActive(canShow);
    }
}
