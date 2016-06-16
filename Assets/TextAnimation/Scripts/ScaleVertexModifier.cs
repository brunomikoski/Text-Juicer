using UnityEngine;

public class ScaleVertexModifier : BaseVertexModifier
{
    [SerializeField]
    private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 1));
    public override void Apply(float progress, ref UIVertex uiVertex)
    {
        uiVertex.position.y = curve.Evaluate(progress)*uiVertex.position.y;
        uiVertex.position.x = curve.Evaluate(progress)*uiVertex.position.x;

    }
}