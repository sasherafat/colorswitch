using UnityEngine;

public class MoverLine : MonoBehaviour
{
    public float moveSpeed = 5f;
    private void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.PingPong(Time.time * moveSpeed, 8f) - 4f;

        transform.position = pos;
    }
}
