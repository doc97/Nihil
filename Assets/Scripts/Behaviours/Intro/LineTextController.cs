using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineTextController : MonoBehaviour
{
    [MinMaxRangeAttribute(0, 3)]
    public MinMaxRange delayRange;
    public float finishDelaySec;

    private System.Random rng;
    private Text text;
    private string[] lines;
    private int linesShown;

    void Start()
    {
        rng = new System.Random();
        text = GetComponent<Text>();
        ParseLines();
        StartCoroutine(ShowLines());
    }

    private void ParseLines()
    {
        lines = text.text.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
    }

    private IEnumerator ShowLines()
    {
        text.text = "";
        while (linesShown++ < lines.Length)
        {
            float delaySec = delayRange.GetRandomValue();
            yield return new WaitForSeconds(delaySec);

            string newText = "";
            for (int i = 0; i < linesShown; i++)
                newText += lines[i] + "\n";
            text.text = newText;
        }
        yield return new WaitForSeconds(finishDelaySec);
        Signals.EmitIntroFinished();
    }
}
