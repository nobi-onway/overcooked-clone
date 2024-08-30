using System;

public interface IProgressTracker
{
    public float ProgressValue { get; }
    public event Action<float> OnProgressChange;
}
