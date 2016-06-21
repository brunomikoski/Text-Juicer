using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TextAnimation.Example
{

    public class Main : MonoBehaviour
    {
        [SerializeField]
        private Button backButton;
        [SerializeField]
        private Button forwardButton;

        private TextAnimator[] textAnimators;

        private int currentIndex = -1;

        private void Awake()
        {
            textAnimators = GetComponentsInChildren<TextAnimator>(true);

            backButton.onClick.AddListener(OnClickBack);
            forwardButton.onClick.AddListener(OnClickForward);


            currentIndex = Random.Range(0, textAnimators.Length);
            Show();
        }

        private void ShowNext()
        {
            currentIndex = (currentIndex + 1)%textAnimators.Length;
            Show();
        }

        private void ShowPrevious()
        {
            currentIndex = (currentIndex + (textAnimators.Length - 1)) % textAnimators.Length;
            Show();
        }

        private void Show()
        {
            for (int i = 0; i < textAnimators.Length; i++)
            {
                TextAnimator textAnimator = textAnimators[i];
                bool shouldActivate = i == currentIndex;
                textAnimator.gameObject.SetActive(shouldActivate);
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
