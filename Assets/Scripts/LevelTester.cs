using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTester : MonoBehaviour
{
    [SerializeField] DialogueView _dialogueView;
    [SerializeField] DialogueData _dialogue01;
    [SerializeField] DialogueData _dialogue02;
    [SerializeField] DialogueData _dialogue03;

    bool toggleUI = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (toggleUI)
            {
                _dialogueView.Display(_dialogue01);
                toggleUI = false;
            }
            else
            {
                _dialogueView.CloseDisplay();
                toggleUI = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (toggleUI)
            {
                _dialogueView.Display(_dialogue02);
                toggleUI = false;
            }
            else
            {
                _dialogueView.CloseDisplay();
                toggleUI = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (toggleUI)
            {
                _dialogueView.Display(_dialogue03);
                toggleUI = false;
            }
            else
            {
                _dialogueView.CloseDisplay();
                toggleUI = true;
            }
        }
    }
}
