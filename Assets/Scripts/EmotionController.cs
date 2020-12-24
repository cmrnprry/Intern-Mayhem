using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionController : MonoBehaviour
{
    //Bro I am coding so bad bc i have no idea how anything talks to each other
    //so i know this will probably change but until then fight me

    public GameObject wheel;

    private bool isOn = false;
    private Image w;
    void Start()
    {
        w = wheel.GetComponent<Image>();
    }

    void CheckWheelVisible()
    {
        isOn = !isOn;
        wheel.SetActive(isOn);

        if (isOn) { StartCoroutine(ChooseEmotion()); }
        else { StopAllCoroutines(); }
    }

    private void Update()
    {
        //For Debugging / Testing
        //Delete later :)

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckWheelVisible();
        }

    }

    //I feel like there's a better way to do this
    //like instead of it here, in the whatever script that checks if the player is in place have it do something like:
    // player in place? cool. Allow player to choose emotion BUT if more than X time passes, a random wrong emotion is chosen and player looses some from ratings
    // but for now it works bc that system isnt in place yet
    
    //I also think the hotkey/costume system will work similar to this one? Although it might instead just listen for any key and then restart itself if it cant find the right one?'
    IEnumerator ChooseEmotion()
    {
        yield return new WaitUntil(()=> (Input.GetButton("One")) || (Input.GetButton("Two")) || (Input.GetButton("Three")) || (Input.GetButton("Four")) || (Input.GetButton("Five")));
      
        if (Input.GetButton("One")) //Happy
        {
            Debug.Log("Happy");
        }
        else if (Input.GetButton("Two")) //Sad
        {
            Debug.Log("Sad");
        }
        else if (Input.GetButton("Three")) //Laugh
        {
            Debug.Log("Laugh");
        }
        else if (Input.GetButton("Four")) //Surprise
        {
            Debug.Log("Surprise");
        }
        else if (Input.GetButton("Five")) //Scared
        {
            Debug.Log("Scared");
        }
    }
}
