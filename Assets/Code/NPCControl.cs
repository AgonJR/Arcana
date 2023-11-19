using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private bool colorToggler = false;
    public void ToggleColor()
    {
        GetComponent<MeshRenderer>().material.color = colorToggler ? Color.red : Color.blue;
        colorToggler = !colorToggler;
    }

}
