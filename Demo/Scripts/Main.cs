using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace BrunoMikoski.TextJuicer.Example
{

    public class Main : MonoBehaviour
    {
        [SerializeField]
        private Button backButton;
        [SerializeField]
        private Button forwardButton;

        private JuicedText[] juicedTexts;

        private int currentIndex = -1;

        private void Awake()
        {
            juicedTexts = GetComponentsInChildren<JuicedText>(true);

            backButton.onClick.AddListener(OnClickBack);
            forwardButton.onClick.AddListener(OnClickForward);


            currentIndex = Random.Range(0, juicedTexts.Length);
            Show();
        }

        private void ShowNext()
        {
            currentIndex = (currentIndex + 1)%juicedTexts.Length;
            Show();
        }

        private void ShowPrevious()
        {
            currentIndex = (currentIndex + (juicedTexts.Length - 1)) % juicedTexts.Length;
            Show();
        }

        private void Show()
        {
            for (int i = 0; i < juicedTexts.Length; i++)
            {
                JuicedText juicedText = this.juicedTexts[i];
                bool shouldActivate = i == currentIndex;
                juicedText.gameObject.SetActive(shouldActivate);
            }
        }


        private void OnDestroy()
        {
            forwardButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
        }

        private void OnClickForward()
        {
            ShowNext();
        }

        private void OnClickBack()
        {
            ShowPrevious();
        }
    }


}
