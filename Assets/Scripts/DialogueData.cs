using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue", fileName = "DLG_")]
public class DialogueData : ScriptableObject
{
    [Multiline]
    [SerializeField] string _dialogue = "...";
    [SerializeField] string _characterName = "...";
    [SerializeField] Sprite _portrait = null;

    public string Dialogue => _dialogue;
    public string CharacterName => _characterName;
    public Sprite Portrait => _portrait;


}
