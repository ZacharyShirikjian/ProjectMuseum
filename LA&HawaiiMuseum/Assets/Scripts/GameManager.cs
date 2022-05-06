using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public int numSouvenirs = 0;
    public int totalSouvenirs = 20;
    public bool canExit = false;
    //public string curInteractable = "";

    //REFERENCES//
    [SerializeField] private GameObject interactPrompt;
     private TextMeshProUGUI interactPromptText;
    // Start is called before the first frame update
    void Start()
    {
        numSouvenirs = 0;
        totalSouvenirs = 20;
        interactPromptText = interactPrompt.GetComponent<TextMeshProUGUI>();
        interactPrompt.SetActive(false);
    }

    public void UpdateInteractUI(string interactable)
    {
        interactPrompt.SetActive(true);
        if(interactable == "")
        {
            interactPromptText.text = "";
            interactPrompt.SetActive(false);
        }

        else if(interactable == "Jeffu")
        {
            interactPromptText.text = "Talk";
        }

        else if(interactable == "Image")
        {
            interactPromptText.text = "Read";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
