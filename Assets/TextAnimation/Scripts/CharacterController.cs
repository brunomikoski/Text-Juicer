using System;
using UnityEngine;

[Serializable]
public struct CharacterController
{
    private float progress;
    public float Progress { get { return progress; } }
    private float perCharacterAnimationDelay;
    private float animationTime;


    public CharacterController(float targetAnimationTime, float targetPerCharacterAnimationDelay)
    {
        progress = 0.0f;
        animationTime = targetAnimationTime;
        perCharacterAnimationDelay = targetPerCharacterAnimationDelay;
    }

    public void UpdateTime(float time)
    {
        if (time < perCharacterAnimationDelay)
            return;

        progress = Mathf.Clamp((time - perCharacterAnimationDelay)/animationTime, 0.0f, 1.0f);
        //Debug.Log("Progress "+progress);

    }
}