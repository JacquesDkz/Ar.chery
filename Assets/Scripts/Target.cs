using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        if (_renderer == null)
            VisualDebug.Console.Log("Target ne poss�de pas de renderer");
    }
    public void Hit()
    {
        VisualDebug.Console.Log("Cible touch�e !");
        _renderer.material.color = Color.red;
    }
}
