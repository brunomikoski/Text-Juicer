using UnityEngine;

public class AxixVertexModifier : BaseVertexModifier
{
    [SerializeField]
    private AnimationCurve curve = new AnimationCurve(new Keyframe(0,1));

    public override void Apply(float progress, ref UIVertex uiVertex)
    {
        uiVertex.position.y *= curve.Evaluate(progress);
    }
}