using System;
using UnityEngine;

// Pretty much just a class that holds the info for a correct audience position.
public class AudienceSlot : TimeSlot
{
    public static readonly float EMOTION_SCORE = 5f;

    public static readonly float POSTION_MAX_SCORE = 10f;

    // The distance from the correct position where the player will be given a perfect score.
    public static readonly float POSTION_MIN_DISTANCE = 0.01f;

    // The maximum distance from the correct position the player is given a score, controls (linear) scale
    public static readonly float POSTION_MAX_DISTANCE = 5f;

    public static readonly float COSTUME_SCORE = 5f;

    [NonSerialized]
    public Vector3 CorrectPostion; // Mostly for convience, set to be transform.position on start.

    public Emotion CorrectEmotion;

    // The correct Costume, something like public Costume correctCostume;

    /// <summary>
    /// Gives an accuracy score based on the given position, emotion and (at some point) costume.
    /// </summary>
    public float GetOverallAccuracy(Vector3 pos, Emotion emotion)
    {
        float score = GetEmotionAccuracy(emotion);

        score += GetPositionalAccuracy(pos);

        score += GetCostumeAccuracy();

        return score; // Maybe we want some sort of difficulty curve? like based off the time given?
    }

    public float GetEmotionAccuracy(Emotion emotion)
    {
        return emotion == CorrectEmotion ? EMOTION_SCORE : 0f;
    }

    public float GetPositionalAccuracy(Vector3 pos)
    {
        float dist = (CorrectPostion - pos).magnitude;

        if (dist < POSTION_MIN_DISTANCE)
        {
            return POSTION_MAX_SCORE;
        }

        if (dist > POSTION_MAX_DISTANCE)
        {
            return 0;
        }

        // This is just a linear scale for the score
        return POSTION_MAX_SCORE * ((POSTION_MAX_DISTANCE - dist) / POSTION_MAX_DISTANCE);
    }

    public float GetCostumeAccuracy( /*Costume costume*/ )
    {
        return COSTUME_SCORE;
    }

    private void Start()
    {
        CorrectPostion = transform.position;
    }
}
