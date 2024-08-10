using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogObj;
    public Sprite profile;
    public Text speechTxt;
    public Text actorNameTxt;
    

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] sentences;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator TypeSentence() {
        foreach (char letter in sentences[index].ToCharArray()) {
            speechTxt.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Speech(string[] txt) {
        if (!isShowing) {
            dialogObj.SetActive(true);
            sentences= txt;
            isShowing = true;
            StartCoroutine(TypeSentence());
        }
    }
}
