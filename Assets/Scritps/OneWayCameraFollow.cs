using UnityEngine;

public class OneWayCameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 6f;

    private void LateUpdate()
    {
        if (target == null)
            return;

        if(target.position.y > transform.position.y)
        {
            Vector3 targetPosition = new Vector3(transform.position.x,target.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed* Time.deltaTime);
        }
    }
}
