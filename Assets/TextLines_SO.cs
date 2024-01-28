using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextLines_SO", menuName = "GGJ2024_Built-inRP/TextLines_SO", order = 0)]
public class TextLines_SO : ScriptableObject {
    public AudioClip voiceLines;
    public List<TextLine> textLines = new List<TextLine>();
    [Serializable]
    public class TextLine{
        public string line;
        public float timeInSec;
    }
}
