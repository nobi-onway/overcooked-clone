using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStovableObject
{
    public bool IsStovable { get; }
    public void Stove();
    public float GetStoveProgress();
}
