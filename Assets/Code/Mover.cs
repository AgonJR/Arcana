using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    public Transform Target;

    private NavMeshAgent nmAgent;

    public float moveX = 0.0f;
    public float moveY = 0.0f;

    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        DetectPlayerInput();

        Target.position = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z + moveY);

        nmAgent.SetDestination(Target.position);

    }

    private void DetectPlayerInput()
    {
        moveX = 0.0f; 
        moveY = 0.0f;

        if ( Input.GetKey(KeyCode.W) ) { moveX += 3.0f; }
        if ( Input.GetKey(KeyCode.S) ) { moveX -= 3.0f; }
        if ( Input.GetKey(KeyCode.D) ) { moveY += 3.0f; }
        if ( Input.GetKey(KeyCode.A) ) { moveY -= 3.0f; }

        if ( moveX != 0 && moveY != 0 )
        {
            moveX /= 2;
            moveY /= 2;
        }
    }
}
