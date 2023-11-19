using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject InteractionIndicator;
    
    private NPCControl npcRef = null;

    void Start()
    {
        npcRef = gameObject.GetComponent<NPCControl>();
    }

    void OnTriggerEnter(Collider collider)
    {
        PlayerControl pc = collider.gameObject.GetComponent<PlayerControl>();

        if ( pc != null )
        {
            pc.InteractableObjectsInRange.Add(this);
            InteractionIndicator.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        PlayerControl pc = collider.gameObject.GetComponent<PlayerControl>();

        if ( pc != null )
        {
            pc.InteractableObjectsInRange.Remove(this);
            InteractionIndicator.SetActive(false);
        }
    }

    public void ProcessInteraction()
    {
        if ( npcRef != null )
        {
            npcRef.ToggleColor();
        }
    }
}
