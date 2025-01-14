using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualDebug : MonoBehaviour
{
    public static VisualDebug Console;
    [SerializeField] private TMP_Text _textBox;

    private void Awake()
    {   
        if (Console != null && Console != this)
        {
            Destroy(this);
        }
        else
        {
            Console = this;
        }
    }

    public void Log(string line)
    {
        _textBox.text += "\n> " + line;
    }


}
