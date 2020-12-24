using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeyBar : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChooseKey());
    }

    private void Update()
    {
        //For Debugging / Testing
        //Delete later :)

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StopAllCoroutines();
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            StartCoroutine(ChooseKey());
        }

    }

    //Hotkeys only go up to 5 rn bc that's what I have in the Input Manager and I'm, lazy B)
    IEnumerator ChooseKey()
    {
        yield return new WaitUntil(() => (Input.anyKey));

        if (Input.GetButtonDown("One")) //Happy
        {
            Debug.Log("Option One");
        }
        else if (Input.GetButtonDown("Two")) //Sad
        {
            Debug.Log("Option Two");
        }
        else if (Input.GetButtonDown("Three")) //Laugh
        {
            Debug.Log("Option Three");
        }
        else if (Input.GetButtonDown("Four")) //Surprise
        {
            Debug.Log("Option Four");
        }
        else if (Input.GetButtonDown("Five")) //Scared
        {
            Debug.Log("Option Five");
        }

        StartCoroutine(ChooseKey());
    }
}
