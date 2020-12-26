using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Emotion
{
    Happy = 0, Sad = 1, Laugh = 2, Surprise = 3, Scared = 4
}

public class EmotionController : MonoBehaviour
{
    //Bro I am coding so bad bc i have no idea how anything talks to each other
    //so i know this will probably change but until then fight me

    [SerializeField]
    private GameObject wheel;

    private Emotion e;
    public bool isOn = false;
    private Image w;
    void Start()
    {
        w = wheel.GetComponent<Image>();
    }

    public void CheckWheelVisible()
    {
        isOn = !isOn;
        //maybe add a lil animation here?
        wheel.SetActive(isOn);

        if (isOn)
        { StartCoroutine(ChooseEmotion()); }
        else
        { StopAllCoroutines(); }
    }

    public Emotion GetCurrentEmotion()
    {
        return e;
    }

    //I feel like there's a better way to do this
    //like instead of it here, in the whatever script that checks if the player is in place have it do something like:
    // player in place? cool. Allow player to choose emotion BUT if more than X time passes, a random wrong emotion is chosen and player looses some from ratings
    // but for now it works bc that system isnt in place yet
    IEnumerator ChooseEmotion()
    {
        yield return new WaitUntil(() => (Input.GetButton("One")) || (Input.GetButton("Two")) || (Input.GetButton("Three")) || (Input.GetButton("Four")) || (Input.GetButton("Five")));

        if (Input.GetButton("One")) //Happy
        {
            Debug.Log("Happy");
            e = Emotion.Happy;
        }
        else if (Input.GetButton("Two")) //Sad
        {
            Debug.Log("Sad");
            e = Emotion.Sad;
        }
        else if (Input.GetButton("Three")) //Laugh
        {
            Debug.Log("Laugh");
            e = Emotion.Laugh;
        }
        else if (Input.GetButton("Four")) //Surprise
        {
            Debug.Log("Surprise");
            e = Emotion.Surprise;
        }
        else if (Input.GetButton("Five")) //Scared
        {
            Debug.Log("Scared");
            e = Emotion.Scared;
        }

        //Show some indicator of what was chosen

        //wait a lil before turning it off
        yield return new WaitForSecondsRealtime(2f);

        CheckWheelVisible();
    }
}
