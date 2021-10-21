using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogueView : MonoBehaviour
{
    [SerializeField] GameObject _panel = null;
    [SerializeField] Text _dialogueTextUI = null;
    [SerializeField] Text _characterNameTextUI = null;
    [SerializeField] Image _characterPortraitUI = null;

    TextWriter textWriter;
    float _textSpeed;

    void Start()
    {
        CloseDisplay();
        textWriter = GetComponent<TextWriter>();
    }

    public void Display(DialogueData data)
    {
        //enable the panel
        _panel.SetActive(true);
        //////set panel data
        //get text and set speed
        _textSpeed = data.TextDelay;
        _dialogueTextUI.text = data.Dialogue;
        textWriter.AddWriter(_dialogueTextUI, data.Dialogue, _textSpeed);

        _characterNameTextUI.text = data.CharacterName;
        _characterPortraitUI.sprite = data.Portrait;

    }

    public void CloseDisplay()
    {
        _panel.SetActive(false);
    }
}
