using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] Text _dialogueTextUI;
    [SerializeField] Text _characterNameTextUI;
    [SerializeField] Image _characterPortraitUI;

    Vector2 showPivot = new Vector2(0f, 0f);
    Vector2 hidePivot = new Vector2(0f, 0f);

    float moveSpeed = 0.01f;
    bool movingUp = false;

    void Start()
    {
        CloseDisplay();
        //_panel.transform.position.y = _panel.transform.position.y - 1000;// * Vector3.down * 1000;
    }

    void FixedUpdate()
    {
        if(movingUp = true)
        {
            if(_panel.transform.position.y < transform.position.y)
                _panel.transform.Translate(Vector3.up * moveSpeed);
        }
        else
        {
            if (_panel.transform.position.y > transform.position.y-1000)
                _panel.transform.Translate(Vector3.down * moveSpeed);
        }
    }

    public void Display(DialogueData data)
    {
        //enable the panel
        _panel.SetActive(true);
        //set panel data
        _dialogueTextUI.text = data.Dialogue;
        _characterNameTextUI.text = data.CharacterName;
        _characterPortraitUI.sprite = data.Portrait;

        Debug.Log("Panel x = " + _panel.transform.position.x + "Panel y = " + _panel.transform.position.y);
        //move the panel upwards
        movingUp = true;
        //while(_panel.transform.position.y < transform.position.y)
            //_panel.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    public void CloseDisplay()
    {
        //move panel downwards
        movingUp = false;
        //while (_panel.transform.position.y > transform.position.y-1000)
            //_panel.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        //disable the panel
        _panel.SetActive(false);
    }
}
