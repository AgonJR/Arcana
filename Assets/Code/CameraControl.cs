using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform FollowTarget;

    void LateUpdate()
    {
        transform.position = FollowTarget.position;
    }
}
