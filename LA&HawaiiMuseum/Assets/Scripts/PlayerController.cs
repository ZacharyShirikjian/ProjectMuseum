using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //INPUT ACTIONS//
    public InputActionReference interact;
    public InputActionReference move;

    //REFERENCES//
    private Rigidbody rb;
    private GameManager gm;

    //VARIABLES//
    public float speed;
    public bool canMove = true;
    public bool canInteract = false;
    public Vector3 inputVector; //gets input from player for movement
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Calls interact method if player presses space
        //Same as Old Input System's Input.GetKeyDown
        if (interact.action.triggered)
        {
            Interact();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            float horizontal = move.action.ReadValue<Vector2>().x;
            float vertical = move.action.ReadValue<Vector2>().y;
            Vector3 movePlayer = new Vector3(horizontal, vertical, 0);
            rb.AddForce(movePlayer * speed, ForceMode.Force);

        }
    }
    public void Interact()
    {
        Debug.Log("Interacting");
        gm.UpdateInteractUI("");
    }

    private void OnEnable()
    {
        move.action.Enable();
        interact.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
        interact.action.Disable();
    }
}
