using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeybindManager : MonoBehaviour
{
    // Initializing variables.
    [Header("Visual Components:")]
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;

    // Initializing variables upon start.
    private void Start()
    {
        buttonText.text = PlayerPrefs.GetString(buttonText.tag);
    }
    
    // Keybind remapping handling.
    private void Update()
    {
        if(buttonText.text == "...")
        {
            button.interactable = false;

            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if(Input.GetKey(keycode))
                {
                    buttonText.text = keycode.ToString();
                    PlayerPrefs.SetString(buttonText.tag, keycode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
        else
        {
            button.interactable = true;
        }
    }

    // Change keybind function handling.
    public void ChangeKey(TextMeshProUGUI buttonText)
    {
        buttonText.text = "...";
        button.interactable = false;
    }
}