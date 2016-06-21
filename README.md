# TextAnimation
Simple text animation controller for Unity Text, feel free to create PR for new effects and using on your project! 



###### Controlling the animation
Basically you can access and change the progress of the animation by the animator itself, or using the helpers inside the TextAnimation, by simply caling, `Play()`, `Stop()` and `Restart()`

###### Adding new effects
Is quite simple, you just need to extend the BaseVertexModifier, and you have access to change whatever you want, in the example bellow, is using a curve to simple multiply the Y from the position itself, generating this effect

```csharp
using UnityEngine;

namespace TextAnimation.Effects
{
    public class YVertexModifier : BaseVertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0,1));

        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            uiVertex.position.y *= curve.Evaluate(charController.Progress);
        }
    }
}
```
The result will be something like that:

![](https://thumbs.gfycat.com/UntimelyDazzlingBrahmancow-size_restricted.gif)

###### Multiple Effects
You can add multiple effects at same time, like the PerCharacter and the X Modifier
![](https://thumbs.gfycat.com/BestGrayCusimanse-size_restricted.gif)

Right now this is the modifiers I come up with:
- X 
![](https://thumbs.gfycat.com/TautHarmfulElver-size_restricted.gif) 
- Y 
![](https://thumbs.gfycat.com/ClosedKlutzyCardinal-size_restricted.gif)
- Per Character Color Modifier
- Cylinder
- Scale Vertex Modifier



> Inspired in this post from [reddit]( https://www.reddit.com/r/Unity3D/comments/3tzwb9/percharacter_text_animations_with_unity_ui/), and the awesome [ui-extensions](https://bitbucket.org/ddreaper/unity-ui-extensions)  


