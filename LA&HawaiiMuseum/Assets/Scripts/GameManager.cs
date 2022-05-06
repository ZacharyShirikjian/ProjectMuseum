using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    //INPUT ACTION REFRENCES//

    //MENUS//
    public InputActionReference menuSubmit;
    public InputActionReference menuClose;
    public InputActionReference imageZoomIn;

    //VARIABLES//
    public int numSouvenirs = 0;
    public int totalSouvenirs = 20;
    public bool canExit = false;
    public bool imageOpen = false;

    //public string curInteractable = "";

    //REFERENCES//
    [SerializeField] private GameObject interactPrompt;
     private TextMeshProUGUI interactPromptText;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject DialogueBox;
    private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI curSouvenirs;

    public GameObject curInteractable;
    public GameObject imageDisplay; 
    public List<Sprite> imageFrames = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        numSouvenirs = 0;
        totalSouvenirs = 20;
        interactPromptText = interactPrompt.GetComponent<TextMeshProUGUI>();
        interactPrompt.SetActive(false);
        imageDisplay.SetActive(false);
        dialogueText = DialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        dialogueText.text = "";
        curSouvenirs.text = numSouvenirs.ToString();
        DialogueBox.SetActive(false);
        curInteractable = null;
    }

    public void UpdateInteractUI(string interactable)
    {
        interactPrompt.SetActive(true);
        if (interactable == "")
        {
            interactPromptText.text = "";
            interactPrompt.SetActive(false);
        }

        else if (interactable != "")
        {
            interactPromptText.text = interactable;
        }
    }
    // Update is called once per frame
    void Update()
    {
        curSouvenirs.text = numSouvenirs.ToString();
        //If player's looking at image and presses Space
        //Close the Image
        if (menuClose.action.triggered && imageDisplay.activeSelf == true)
        {
            CloseImage();
        }

        if (numSouvenirs >= totalSouvenirs)
        {
            canExit = true;
        }

        else if(numSouvenirs < totalSouvenirs)
        {
            canExit = false;
        }

    }

    public void PauseGame()
    {

    }

    public void OpenImage()
    {
        Debug.Log("opening image");
        OnEnable();
        imageDisplay.SetActive(true);
        imageOpen = true;
        imageDisplay.GetComponent<Image>().sprite = curInteractable.GetComponent<ImageScript>().imageSprite;
        DialogueBox.SetActive(true);
        dialogueText.text = curInteractable.GetComponent<ImageScript>().imageDescription.ToString();
        player.canInteract = false;
        player.canMove = false;
       
    }

    //Disable menu, renable player control
    public void CloseImage()
    {
        Debug.Log("closing image");
        imageDisplay.SetActive(false);
        imageOpen = false;
        DialogueBox.SetActive(false);
        dialogueText.text = "";
        OnDisable();
        player.OnEnable();
        player.canInteract = true;
        player.canMove = true;
        numSouvenirs++;

    }

    private void OnEnable()
    {
        menuClose.action.Enable();
        menuSubmit.action.Enable();
        imageZoomIn.action.Enable();
    }

    private void OnDisable()
    {
        menuClose.action.Disable();
        menuSubmit.action.Disable();
        imageZoomIn.action.Disable();
    }

}
