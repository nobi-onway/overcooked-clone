using System;

public enum EStoveState { UNCOOKED = 0, COOKED = 1, BURNED = 2 }
public interface IStovableObject
{
    public bool IsStovable { get; }
    public void Stove();
    public float GetStoveProgress();
    public EStoveState StoveState { get; }
    public event Action<EStoveState> OnStoveStateChange;
}
