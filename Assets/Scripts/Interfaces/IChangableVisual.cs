using System;

public interface IChangableVisual
{
    public int VisualIndex { get; }
    public event Action<int> OnVisualChange;
}
