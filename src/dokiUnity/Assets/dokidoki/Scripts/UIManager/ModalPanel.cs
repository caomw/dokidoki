using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System;


public class ModalPanel : MonoBehaviour
{
    public Text titleText;
    public Text messageText;
    public Button yesButton;
    public Button noButton;

    public void Choice(string title, string message, UnityAction<bool> yesEvent)
    {
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() => { yesEvent(true); });
        yesButton.onClick.AddListener(closePanel);

        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(closePanel);

        this.titleText.text = title;
        this.messageText.text = message;
    }

    public void Choice(string title, string message, UnityAction<bool, System.Object> yesEvent, System.Object yesParameter)
    {
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() => { yesEvent(true, yesParameter); });
        yesButton.onClick.AddListener(closePanel);

        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(closePanel);

        this.titleText.text = title;
        this.messageText.text = message;
    }

    public void Choice(string title, string message, UnityAction<bool> yesEvent, UnityAction<bool> noEvent)
    {
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() => { yesEvent(true); });
        yesButton.onClick.AddListener(closePanel);

        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(() => { noEvent(true); });
        noButton.onClick.AddListener(closePanel);

        this.titleText.text = title;
        this.messageText.text = message;
    }

    void closePanel()
    {
        this.gameObject.SetActive(false);
    }
}