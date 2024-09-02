using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject InteractionIndicator;
    
    private NPCControl    _npc = null;
    private PlayerControl _pc  = null;

    void Start()
    {
        _npc = gameObject.GetComponent<NPCControl>();
    }

    void OnTriggerEnter(Collider collider)
    {
        _pc = _pc == null ? collider.gameObject.GetComponent<PlayerControl>() : _pc;

        if ( _pc != null )
        {
            _pc.InteractableObjectsInRange.Add(this);
                InteractionIndicator.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        _pc.InteractableObjectsInRange.Remove(this);
            InteractionIndicator.SetActive(false);
    }

    public void ProcessInteraction()
    {
        if ( _npc != null ) { _npc.ToggleColor(); }
    }
}
