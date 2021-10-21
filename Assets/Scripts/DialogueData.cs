using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Dialogue", fileName = "DLG_")]
public class DialogueData : ScriptableObject
{
    /*
    [Multiline]
    [SerializeField] string _dialogue = "...";
    [SerializeField] string _characterName = "...";
    [SerializeField] Sprite _portrait = null;

    
    */

    //public GameObject prefab;
    public string diaName;
    public string dialogue;
    public string characterName;
    public Sprite portrait;
    public float textDelay;

    public string DiaName => diaName;
    public string Dialogue => dialogue;
    public float TextDelay => textDelay;
    public string CharacterName => characterName;
    public Sprite Portrait => portrait;

}
