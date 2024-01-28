using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextManager : Singleton<TextManager>
{
    public TMP_Text text;
    public TextLines_SO textLines_SO;
    public int lineCounter;
    IEnumerator inst = null;

    // Start is called before the first frame update
    void Start()
    {
        StartParagraph(textLines_SO);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartParagraph(TextLines_SO textLines_SO)
    {
        this.textLines_SO = textLines_SO;
        lineCounter = 0;
        NextLine();
    }
    public void NextLine()
    {
        if (lineCounter < textLines_SO.textLines.Count)
        {
            text.text = textLines_SO.textLines[lineCounter].line;
            inst = WaitUntilNextLine(textLines_SO.textLines[lineCounter].timeInSec);
            StartCoroutine(inst);
        }
        else
        {
            Clear();
            return;
        }
    }
    void Clear()
    {
        if (inst != null) StopCoroutine(inst);
        inst = null;
        textLines_SO = null;
        lineCounter = 0;
        text.text = "";
    }
    IEnumerator WaitUntilNextLine(float sec)
    {
        yield return new WaitForSeconds(sec);
        lineCounter++;
        NextLine();
    }

    private void OnDisable()
    {
        Clear();
    }
}
