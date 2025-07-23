using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
