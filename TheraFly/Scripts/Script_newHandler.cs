//Ka Man CHOI 50000567 - TheraFly
//show new handler after player go pass the trigger box in previous checkpoint
// character from Maximo and animate in unity
// references: youtube tutorials https://youtu.be/0QA2O7juuWQ ; https://youtu.be/IBP8T3PR5wE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_newHandler : MonoBehaviour
{
    public GameObject newHandler;   
    private bool showObject;

    void Start()
    {
        //not to show new handler before trigger
        newHandler.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
            showObject = true;
            newHandler.SetActive(true);
            print("triggered");
    }

    void Update()
    {
        if (showObject)
        {
            newHandler.SetActive(true);
            print("true update");
        }
    }

    public void ShowContent()
    {
        showObject = true;
        newHandler.SetActive(true);
    }

    public void HideContent()
    {
        newHandler.SetActive(false);
        showObject = false;
    }
}
