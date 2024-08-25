using System;

public interface IController<T> where T : Enum
{
    public T State { get; set; }
    public event Action<T> OnStateChange;
}
    
