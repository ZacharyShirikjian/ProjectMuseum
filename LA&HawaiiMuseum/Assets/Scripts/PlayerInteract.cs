using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Reference to player script
    private PlayerController player;

    //Reference to GameManager script 
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Image")
        {
            player.canInteract = true;
            gm.curInteractable = other.gameObject;
            gm.UpdateInteractUI("Read");
        }
        else if (other.gameObject.tag == "Jeffu")
        {
            player.canInteract = true;
            gm.curInteractable = other.gameObject;
            gm.UpdateInteractUI("Talk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Image" || other.gameObject.tag == "Jeffu")
        {
            player.canInteract = true;
            gm.curInteractable = null;
            gm.UpdateInteractUI("");
        }
    }
}
