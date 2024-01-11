using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_cp_showDiaText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Set the initial text
        textMeshPro.SetText("");
    }


    private void OnTriggerEnter(Collider other)
    {
        textMeshPro.SetText("Are you really going nuts? Have you forgotten you're a cop? I'm not your handler anymore!");
    }
}
