using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform FollowTarget;

    void Update()
    {
        transform.position = FollowTarget.position;
    }
}
