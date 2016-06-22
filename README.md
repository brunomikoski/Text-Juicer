# Text Juice
Is a plugin to allow you do "per-character-animation" on text fields, like this one:
![](https://thumbs.gfycat.com/UntimelyDazzlingBrahmancow-size_restricted.gif)

[EXAMPLES](https://gfycat.com/BlandScholarlyDragonfly)

###### Controlling the animation
This git is a ready to be used as sub-module, so just add to your project anywhere inside the Assets Folder, something like Assets/Text Juicer/

If you don't know how to add as a sub-module you can check this [guide](https://blog.sourcetreeapp.com/2012/02/01/using-submodules-and-subrepositories/)

Or you can just download the [Unity Package](../master/Text%20Juicer%200.0.1.unitypackage.meta)

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


###### Multiple Effects
You can add multiple effects at same time, like the PerCharacter and the X Modifier
![](https://thumbs.gfycat.com/BestGrayCusimanse-size_restricted.gif)

Current Effects:
- X 
- Y 
- Color Modifier
- Cylinder
- Scale Vertex Modifier
- Glitch


You can check effects accessing this link:




> Inspired in this post from [reddit]( https://www.reddit.com/r/Unity3D/comments/3tzwb9/percharacter_text_animations_with_unity_ui/), and the awesome [ui-extensions](https://bitbucket.org/ddreaper/unity-ui-extensions)  


