using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSettings", menuName = "Dialog/DialogSettings")]
public class DialogSettings : ScriptableObject {
    [Header("Settings")]
    public GameObject actor;
    
    [Header("Dialog")]
    public string actorName;
    public string sentence;
    public Sprite speakerSprite;

    public List<Sentences> dialogues = new();
}

[System.Serializable]
public class Sentences {
    public Sprite profile;
    public Languages sentences;
}

[System.Serializable]
public class Languages {
    public string portuguese;
    public string english;
    public string spanish;
}