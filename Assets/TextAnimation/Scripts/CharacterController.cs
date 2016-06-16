using System;
using UnityEngine;

[Serializable]
public struct CharacterController
{
    private float progress;

    public float Progress
    {
        get { return progress; }
    }

    private float startingTime;

    private float internalTime;
    private float finalTime;
    private float totalAnimationTime;

    public CharacterController(float startTime, float targetAnimationTime)
    {
        progress = 0.0f;
        startingTime = startTime;
        finalTime = startingTime + targetAnimationTime;
        totalAnimationTime = finalTime - startTime;
        internalTime = 0;
    }

    public void UpdateTime(float time)
    {
        if (time < startingTime)
            return;


        progress = Mathf.Clamp((time - startingTime)/totalAnimationTime, 0.0f, 1.0f);
    }
}
