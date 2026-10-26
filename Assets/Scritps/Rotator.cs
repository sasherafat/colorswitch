using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 10f;
    private void Update()
    {
        transform.Rotate(0f,0f, rotateSpeed * Time.deltaTime);
    }
}
