using UnityEngine;

public class NPCControl : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if ( collider.gameObject.tag.Equals("Player") )
        {
            Debug.Log(" --- Player Reached Interaction Radius ! ");
        }
    }

}
