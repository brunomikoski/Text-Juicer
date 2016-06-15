using UnityEngine;

public abstract class BaseCharacterModifier : MonoBehaviour
{
    public abstract void Apply(float progress, ref UIVertex uiVertex);
}