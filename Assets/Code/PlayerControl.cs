using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public Transform Target;
    private NavMeshAgent nmAgent;

    [Header("Interaction")]
    public List<InteractableObject> InteractableObjectsInRange;
    

    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        InteractableObjectsInRange = new List<InteractableObject>();
    }

    void Update()
    {
        DetectMouseInput();
        DetectPlayerInput();
    }

    private void DetectPlayerInput()
    {
        // Movement ----

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

        // Interaction -----
        
        if ( Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) )
        {
            if ( InteractableObjectsInRange.Count > 0 )
            {
                Debug.Log(" ---- PLAYER Interacted With [" + InteractableObjectsInRange[0].name + "]");
                InteractableObjectsInRange[0].ProcessInteraction();
            }
        }

    }

    private void DetectMouseInput()
    {
        // Move on Mouse Down
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

        // Interact on Mouse Up
        if ( Input.GetMouseButtonUp(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            
            if (hasHit)
            {
                InteractableObject targetInteractable = hit.transform.gameObject.GetComponent<InteractableObject>();

                if ( targetInteractable != null )
                {
                    if (InteractableObjectsInRange.Contains(targetInteractable))
                    {
                        Debug.Log(" ---- PLAYER CLICKED on INTERACTABLE OBJECT in Range  [" + targetInteractable.name + "]");
                        targetInteractable.ProcessInteraction();
                    }
                    else
                    {
                        Debug.Log(" ---- PLAYER CLICKED on INTERACTABLE OBJECT ~ OUT of Range !  [" + targetInteractable.name + "]");
                    }
                }
            }
        }
    }

}
