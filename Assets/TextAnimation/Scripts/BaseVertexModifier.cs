using UnityEngine;

public abstract class BaseVertexModifier : MonoBehaviour
{
    public abstract void Apply(float progress, ref UIVertex uiVertex);
}