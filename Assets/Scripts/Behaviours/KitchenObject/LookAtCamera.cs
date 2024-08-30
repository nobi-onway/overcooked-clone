using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Update()
    {
        this.transform.forward = -Camera.main.transform.forward;
    }
}
