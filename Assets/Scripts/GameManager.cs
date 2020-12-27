using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public EmotionController ec;
    public HotKeyBar hk;

    public LevelManager level;

    //TESTING TO GET RANDOMTHING
    //DELETE LATER PROBABLY
    public Emotion[] list;

    private Emotion currEmotion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LevelLoop());
    }

    IEnumerator LevelLoop()
    {
        TimeSlot nextSlot = level.slots[0];
        yield return new WaitForSecondsRealtime(nextSlot.TimeToComplete);

        // prolly want to make some helper functions for different slot types if we make them.
        if (!(nextSlot is AudienceSlot))
        {
            // idk dude something, just go to the next one for now.
            level.slots.RemoveAt(0);
            StartCoroutine(LevelLoop());
            yield break;
        }
        //stop player movement
        player.StopMovement();

        //stop costume changes
        hk.StopChoosing();

        //choose emotion
        ec.CheckWheelVisible();
        yield return new WaitUntil(() => !ec.isOn); // Should this time out?

        Emotion e = ec.GetCurrentEmotion();

        AudienceSlot checker = (AudienceSlot)nextSlot;

        //calculate score
        float score = checker.GetOverallAccuracy(player.transform.position, e);
        Debug.Log("Score: " + score);

        //display score (maybe want to show separate scores?)

        //next position / end level
        level.slots.RemoveAt(0);
        player.RestartMovement();
        hk.RestartChoosing();
        if (level.slots.Count > 0)
        {
            StartCoroutine(LevelLoop());
        }
        else
        {
            // end the level or something.
            Debug.Log("Level ended.");
            yield break;
        }
    }
}
