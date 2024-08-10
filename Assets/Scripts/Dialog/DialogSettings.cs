using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "DialogSettings", menuName = "Dialog/DialogSettings")]
public class DialogSettings : ScriptableObject {
    [Header("Settings")]
    public GameObject actor;
    
    [Header("Dialog")]
    public string sentence;
    public Sprite speakerSprite;

    public List<Sentences> dialogues = new();
}

[System.Serializable]
public class Sentences {
    public string actorName; 
    public Sprite profile;
    public Languages sentences;
}

[System.Serializable]
public class Languages {
    public string portuguese;
    public string english;
    public string spanish;

    
}


#if UNITY_EDITOR
[CustomEditor(typeof(DialogSettings))]
    public class BuilderEditor : Editor {
        
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings ds = (DialogSettings)target;

        Languages l = new()
        {
            portuguese = ds.sentence
        };

        Sentences s = new()
        {
            profile = ds.speakerSprite,
            sentences = l
        };

        if (GUILayout.Button("Create Dialogue")) {
            if (ds.sentence != "") {
                ds.dialogues.Add(s);
            
                ds.sentence = "";
                ds.speakerSprite = null;
            }
        }
    }
}

#endif