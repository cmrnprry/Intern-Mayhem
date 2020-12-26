using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public EmotionController ec;
    public HotKeyBar hk;

    //TESTING TO GET RANDOMTHING
    //DELETE LATER PROBABLY
    public Emotion[] list;

    private Emotion currEmotion;

    // Start is called before the first frame update
    void Start()
    {
        ChooseNextEmotion();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Here");
            StartCoroutine(NamedFunction());
        }
    }

    private void ChooseNextEmotion()
    {
        //LMAO RN ITS RANDONM
        //MAYBE MAKE A REAL WAY TO CHOOSE THE NEXT
        //THIS IS GOING TO BE HARD CODED ANYWAYYYYYY
        // or just make max do it......
        int rand = Random.Range(0, 5);
        
        currEmotion = list[rand];
        Debug.Log(currEmotion.ToString());
    }

    IEnumerator NamedFunction()
    {
        yield return new WaitForSecondsRealtime(.25f);

        //stop player movement
        player.StopMovement();

        //stop costume changes
        hk.StopChoosing();

        //choose emotion
        ec.CheckWheelVisible();
        yield return new WaitUntil(() => !ec.isOn);

        Emotion e = ec.GetCurrentEmotion();

        //check correct emotion
        string x = (currEmotion == e) ? "Correct" : "Incorrect";
        Debug.Log(x);

        //Check if correct outfit

        //calculate score

        //display score

        //next position / end level
        ChooseNextEmotion();
        player.RestartMovement();
        hk.RestartChoosing();
    }
}
