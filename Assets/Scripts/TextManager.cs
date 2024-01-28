using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : Singleton<TextManager>
{
    public float delayInSec = 1f;
    public AudioSource audioSource;
    public TMP_Text text;
    private TextLines_SO textLines_SO;
    public int lineCounter;
    IEnumerator inst = null;
    public List<TextLines_SO> paragraphs = new List<TextLines_SO>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartParagraphWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        text.transform.parent.gameObject.SetActive(text.text!="");
    }
    public void StartRandomParagraph()
    {
        int index = Random.Range(0, paragraphs.Count);
        StartParagraph(paragraphs[index]);
        if(paragraphs[index].voiceLines!=null){
            audioSource.clip = paragraphs[index].voiceLines;
            audioSource.Play();
        }
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

    IEnumerator StartParagraphWithDelay()
    {
        yield return new WaitForSeconds(delayInSec);
        StartRandomParagraph();
    }

    private void OnDisable()
    {
        Clear();
    }
}
