using UnityEngine;

public class NPCControl : MonoBehaviour
{

    private bool colorToggler = false;
    public void ToggleColor()
    {
        GetComponent<MeshRenderer>().material.color = colorToggler ? Color.red : Color.blue;
        colorToggler = !colorToggler;
    }

    void OnTriggerEnter(Collider collider)
    {
        PlayerControl pc = collider.gameObject.GetComponent<PlayerControl>();

        if ( pc != null )
        {
            pc.InteractableObjectsInRange.Add(gameObject);
        }
    }


    void OnTriggerExit(Collider collider)
    {
        PlayerControl pc = collider.gameObject.GetComponent<PlayerControl>();

        if ( pc != null )
        {
            pc.InteractableObjectsInRange.Remove(gameObject);
        }
    }

}
