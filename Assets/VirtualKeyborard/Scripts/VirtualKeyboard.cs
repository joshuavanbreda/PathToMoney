using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace VirtualKeyboard
{
    public class VirtualKeyboard : MonoBehaviour
    {
        public KeyboardFunc keyboard;
        public TMP_InputField inputAnswer;
        public CanvasGroup inputArea;

        public Typer typerScript;

        char[] _currentText = new char[0];
        // Start is called before the first frame update
        void Start()
        {
            inputAnswer.onSubmit.AddListener(OnInputFieldSubmit);
#if !UNITY_IOS || UNITY_EDITOR
            inputAnswer.onFocusSelectAll = false;

            keyboard.gameObject.SetActive(false);
            keyboard.onKeyPressEvent = (string character) => {
                inputAnswer.text += character;

                typerScript.GetVirtualKey(character);

                if (typerScript.chooseWord == true)
                {
                    typerScript.checkLetterWordSelect(character);
                }
                //Debug.Log(character);

            };
            keyboard.onBackKeyPressEvent = () =>
            {
                inputAnswer.text = inputAnswer.text.Remove(inputAnswer.text.Length - 1);
            };
            keyboard.onEnterKeyPressEvent = () =>
            {
                inputAnswer.text += "\n";
            };
#else
            keyboard.gameObject.SetActive(false);
#endif
        }

        // Update is called once per frame
        void Update()
        {
            if (inputAnswer.isFocused == false)
            {
                EventSystem.current.SetSelectedGameObject(inputAnswer.gameObject, null);
                inputAnswer.OnPointerClick(new PointerEventData(EventSystem.current));
            }
        }

        private void OnInputFieldSubmit(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                // some stuff with message
                inputAnswer.text = "";
                inputAnswer.Select();
                inputAnswer.ActivateInputField();
            }
        }

        public void ShowKeyboard(bool flag)
        {
            if (flag)
            {
                AnimationHelper.lerpMe(0.2f, (float percent) => {
                    inputArea.alpha = Mathf.Lerp(0, 1, percent);
                }, () => {
                    inputArea.interactable = true;
                    inputArea.blocksRaycasts = true;
                });
                inputAnswer.ActivateInputField();
                inputAnswer.Select();
                inputAnswer.shouldHideMobileInput = true;
                inputAnswer.shouldHideSoftKeyboard = false;
#if !UNITY_IOS || UNITY_EDITOR
                keyboard.ShowKeyboard(true, false);
#endif
            }
            else
            {
                inputArea.interactable = false;
                inputArea.blocksRaycasts = false;
                inputArea.alpha = 0;
                inputAnswer.text = "";
                inputAnswer.shouldHideMobileInput = true;
                inputAnswer.DeactivateInputField();
                EventSystem.current.SetSelectedGameObject(null);
#if !UNITY_IOS || UNITY_EDITOR
                keyboard.ShowKeyboard(false, false);
#endif

            }

        }

        public void OnInputFieldChange()
        {
            string wholdWord = inputAnswer.text;
            char[] listChars = wholdWord.ToCharArray();

            // backup 
            _currentText = listChars;
#if !UNITY_IOS || UNITY_EDITOR
            inputAnswer.caretPosition = _currentText.Length;
#endif

        }


    }
}