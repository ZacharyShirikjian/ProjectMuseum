using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//FPS Controller with Unity's New Input System used for Camera Control (YouTube)
//https://www.youtube.com/watch?v=tXDgSGOEatk

public class PlayerController : MonoBehaviour
{
    
    //INPUT ACTIONS//
    public InputActionReference interact;
    public InputActionReference move;
    public InputActionReference moveMouseX;
    public InputActionReference moveMouseY;
    public InputActionMap menuActionMap;

    [SerializeField] float sensX = 10; //horizontal sensitivity of mouse
    [SerializeField] float sensY = 0.25f; //vertical sensitivity of mouse
    float mouseX, mouseY;

    [SerializeField] float xClamp = 85f; //clamp used to prevent rotation from going too high or low
    float xRotation = 0f;

    //REFERENCES//
    private Rigidbody rb;
    private GameManager gm;
    [SerializeField] Transform playerCamera;

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
        speed = 80;
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

        if(canMove)
        {
            mouseX = Mouse.current.delta.x.ReadValue(); //Get horizontal position of mouse for x, multiply by sensitiviy
            mouseY = Mouse.current.delta.y.ReadValue(); //Get vertical position of mouse for y, multiply by sensitivity

            transform.Rotate(Vector3.up, mouseX * Time.deltaTime); //Vector3.up = y axis
            xRotation -= mouseY; //+= reverses camera controls, -= is better instead
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp); //clamp xRotation in between -xClamp and +xClamp
            Vector3 targetRotation = transform.eulerAngles; //get current rotation of player
            targetRotation.x = xRotation;
            playerCamera.eulerAngles = targetRotation;
            
        }


    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            float horizontal = move.action.ReadValue<Vector2>().x;
            float vertical = move.action.ReadValue<Vector2>().y;
            Vector3 movePlayer = new Vector3(horizontal, 0, vertical);
            rb.AddForce(movePlayer * speed, ForceMode.Force);

        }
    }
    public void Interact()
    {
        Debug.Log("Interacting");
        gm.UpdateInteractUI("");
        if(gm.curInteractable.tag == "Image")
        {
            //Switch to the Image or UI action map
            gm.OpenImage();
            OnDisable();
        }
    }

    public void OnEnable()
    {
        move.action.Enable();
        interact.action.Enable();
    }

    public void OnDisable()
    {
        move.action.Disable();
        interact.action.Disable();
    }
}
