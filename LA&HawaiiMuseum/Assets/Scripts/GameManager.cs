using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //ACTION MAPS//
    public InputActionMap menuActionMap;
    public InputActionMap playerActionMap;

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
        
    }

    public void PauseGame()
    {

    }

    public void OpenImage()
    {
        if(imageOpen == false)
        {
            OnEnable();
            imageDisplay.SetActive(true);
            imageDisplay.GetComponent<Image>().sprite = imageDisplay.GetComponent<ImageScript>().imageSprite;
        }

        else if (imageOpen == true)
        {
            OnDisable();
            imageDisplay.SetActive(true);
            imageDisplay.GetComponent<Image>().sprite = imageDisplay.GetComponent<ImageScript>().imageSprite;
        }
       
    }

    private void OnEnable()
    {
        menuActionMap.Enable();
        playerActionMap.Disable();
    }

    private void OnDisable()
    {
        playerActionMap.Enable();
        menuActionMap.Disable();
    }

}
