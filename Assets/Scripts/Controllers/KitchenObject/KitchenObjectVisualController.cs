using UnityEngine;

public class KitchenObjectVisualController : MonoBehaviour, IObjectVisual
{
    [SerializeField] private Transform[] _visualArray;
    [SerializeField] private Transform _defaultVisual;

    private IChangableVisual _changableVisual;
    
    public Transform CurrentVisual { get; private set; }

    private void Start()
    {
        _changableVisual = GetComponent<IChangableVisual>();

        _changableVisual.OnVisualChange += (index) =>
        {
            Transform visual = index < _visualArray.Length ? _visualArray[index] : _defaultVisual;
            SetVisual(visual);
        };

        ResetVisual();
    }

    public void ResetVisual()
    {
        SetVisual(_defaultVisual);
    }

    private void SetVisual(Transform visual)
    {
        CurrentVisual?.gameObject.SetActive(false);
        CurrentVisual = visual;
        CurrentVisual.gameObject.SetActive(true);
    }
}
