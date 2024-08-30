using System;
using UnityEngine;

public class PlateVisualController : MonoBehaviour, IObjectVisual
{
    [SerializeField] private VisualSetting[] _visualSettings;

    private IChangableVisual _changableVisual;

    private void Start()
    {
        _changableVisual = GetComponent<IChangableVisual>();

        _changableVisual.OnVisualChange += (index) =>
        {
            if(index == -1) { ResetVisual(); return; }

            _visualSettings[index].visual.gameObject.SetActive(true);
        };
    }

    public void ResetVisual()
    {
        for(int i = 0; i < _visualSettings.Length; i++)
        {
            _visualSettings[i].visual.gameObject.SetActive(false);
        }
    }
}

[Serializable]
public struct VisualSetting
{
    public KitchenObjectSettings settings;
    public Transform visual;
}
