using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        VisualDebug.Console.Log("PlayButton.cs : Bouton pressé");
    }
}
