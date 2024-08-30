using System;

public enum ESliceState { UNSLICED = 0, SLICED = 1 }
public interface ISlicableKitchenObject
{
   public bool IsSliced { get; }
   public void Slice();
   public float GetSliceProgress();
   public ESliceState SliceState { get; }
   public event Action<ESliceState> OnSliceStateChange;
}
