using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    #region UnityEditor
    [SerializeField] private Image _progress;
    #endregion

    public float ProgressValue { get; private set; }

    public void SetProgressValue(float value)
    {
        ProgressValue = value;
        _progress.fillAmount = value;
    }

    public void ShowIf(bool canShow)
    {
        this.transform.gameObject.SetActive(canShow);
    }
}
