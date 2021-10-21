using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D dialogueSectionTexture;

    Color headerSectionColor = new Color(53f / 255f, 72f / 255f, 84f / 255f, 1f);

    Rect headerSection;
    Rect dialogueSection;

    static DialogueData dialogueData;

    public static DialogueData DialogueInfo { get { return dialogueData; } }

    [MenuItem("Window/Dialogue Designer")]
    static void OpenWindow()
    {
        DialogueDesignerWindow window = (DialogueDesignerWindow)GetWindow(typeof(DialogueDesignerWindow));
        window.minSize = new Vector2(600, 500);
        //window.maxSize = new Vector2(600, 300);
        window.Show();
    }

    //similar to start or awake
    void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public static void InitData()
    {
        dialogueData = (DialogueData)ScriptableObject.CreateInstance(typeof(DialogueData));
    }

    //initialize texture 2d values
    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        dialogueSectionTexture = Resources.Load<Texture2D>("icons/grad1");
    }

    //similar to update, runs on interaction
    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DialogueSettings();
    }

    //defines rect values and paints textures based on rects
    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        GUI.DrawTexture(headerSection, headerSectionTexture);

        dialogueSection.x = 0;
        dialogueSection.y = 50;
        dialogueSection.width = Screen.width;
        dialogueSection.height = Screen.width - 50;

        GUI.DrawTexture(dialogueSection, dialogueSectionTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Dialogue Designer");

        GUILayout.EndArea();
    }

    void DialogueSettings()
    {
        GUILayout.BeginArea(dialogueSection);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Dialog File Name");
        if (dialogueData.diaName == null || dialogueData.diaName == "")
            dialogueData.diaName = "DLG_";

        dialogueData.diaName = EditorGUILayout.TextField(dialogueData.diaName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Character Name");
        dialogueData.characterName = EditorGUILayout.TextField(dialogueData.characterName);
        //todo: check name length
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        dialogueData.portrait = (Sprite)EditorGUILayout.ObjectField("Portrait", dialogueData.portrait, typeof(Sprite), false, GUILayout.Height(100));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Dialogue");
        dialogueData.dialogue = EditorGUILayout.TextArea(dialogueData.dialogue, GUILayout.Width(400), GUILayout.Height(100));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Text Delay");
        dialogueData.textDelay = EditorGUILayout.Slider(dialogueData.textDelay, 0, 1);
        EditorGUILayout.EndHorizontal();


        if (dialogueData.diaName == null)
        {
            EditorGUILayout.HelpBox("A [file name] is required to save data.", MessageType.Warning);
        }
        else if (GUILayout.Button("Save Asset to File", GUILayout.Height(30)))
        {
            SaveDialogueData();
            this.Close();
        }
        if (GUILayout.Button("Load Asset from File", GUILayout.Height(30)))
        {
            LoadDialogueData();
        }
        GUILayout.EndArea();
    }

    void SaveDialogueData()
    {
        //make folders if they don't exist
        if (!AssetDatabase.IsValidFolder($"Assets/Resources"))
        {
            AssetDatabase.CreateFolder("Assets", "Resources");
            Debug.Log("Creating a new folder at Assets/Resources");
        }
        if (!AssetDatabase.IsValidFolder($"Assets/Resources/CharacterData"))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "CharacterData");
            Debug.Log("Creating a new folder at Resources/CharacterData");
        }

        string dataPath = "Assets/Resources/CharacterData/";
        if (AssetDatabase.IsValidFolder(dataPath))
        {
            Debug.Log("Warning: Data Path is not valid: " + dataPath);
        }

        //create the .asset file
        dataPath += DialogueDesignerWindow.DialogueInfo.diaName + ".asset";
        AssetDatabase.CreateAsset(DialogueDesignerWindow.DialogueInfo, dataPath);
        Debug.Log("New dialog file created at " + dataPath);
    }

    void LoadDialogueData()
    {
        string folderPath = "Assets/Resources/CharacterData/";
        string path = EditorUtility.OpenFilePanel("Open Asset", "Assets/Resources/CharacterData/", "asset");
        if (path.Length != 0) { 
            string shortPath = path.Substring(path.Length + 1 - (folderPath.Length + (path.Length - path.LastIndexOf('/'))));

            if (shortPath.Length != 0)
            {
                DialogueData diaFile = (DialogueData)AssetDatabase.LoadAssetAtPath(shortPath, typeof(DialogueData));
                Debug.Log("Dialog Data loaded from " + shortPath);

                dialogueData.diaName = diaFile.diaName;
                dialogueData.characterName = diaFile.characterName;
                dialogueData.portrait = diaFile.portrait;
                dialogueData.dialogue = diaFile.dialogue;
                dialogueData.textDelay = diaFile.textDelay;
                Repaint();
            }
        }
    }
}