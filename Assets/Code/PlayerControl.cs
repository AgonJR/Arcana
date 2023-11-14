using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public Transform Target;

    private NavMeshAgent nmAgent;

    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        DetectMouseInput();
        DetectPlayerInput();
    }

    private void DetectPlayerInput()
    {
        float moveX = 0.0f; 
        float moveY = 0.0f;

        if ( Input.GetKey(KeyCode.W) ) { moveX += 3.0f; }
        if ( Input.GetKey(KeyCode.S) ) { moveX -= 3.0f; }
        if ( Input.GetKey(KeyCode.D) ) { moveY -= 3.0f; }
        if ( Input.GetKey(KeyCode.A) ) { moveY += 3.0f; }

        if ( moveX != 0 && moveY != 0 )
        {
            moveX /= 2;
            moveY /= 2;
        }

        if ( moveX != 0 || moveY != 0 )
        {
            Target.position = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z + moveY);
            nmAgent.SetDestination(Target.position);
        }
    }

    private void DetectMouseInput()
    {
        if ( Input.GetMouseButton(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            
            if (hasHit)
            {
                Target.position = hit.point;
                nmAgent.SetDestination(Target.position);
            }
        }
    }

}
