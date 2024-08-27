public interface ISlicableKitchenObject
{
   public bool IsSliced { get; }
   public void Slice();
   public float GetSliceProgress();
}
