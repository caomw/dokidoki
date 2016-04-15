using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System;

/// <summary>
/// ModalPanel is a template to create a pop up window to wait for player's option input.
/// ModalPanel has a title, message, Yes button (and No button).
/// External callback function could be passed to this window, and when responding button is clicked, the responding functions would be called.
/// </summary>
public class ModalPanel : MonoBehaviour{
    /// <summary>
    /// Pointer to the titleText GameObject
    /// </summary>
    public Text titleText;
    /// <summary>
    /// Pointer to the messageText GameObject
    /// </summary>
    public Text messageText;
    /// <summary>
    /// Pointer to the yesButton GameObject
    /// </summary>
    public Button yesButton;
    /// <summary>
    /// Pointer to the noButton GameObject
    /// </summary>
    public Button noButton;


    /// <summary>
    /// Show and customize the popup window's title, message, yesButton's callback function
    /// </summary>
    /// <param name="title">Title of the window</param>
    /// <param name="message">Message insidethe window</param>
    /// <param name="yesEvent">Callback function of yesButton</param>
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
    /// <summary>
    /// Show and customize the popup window's title, message, yesButton's callback function and parameters should be passed to the function
    /// </summary>
    /// <param name="title">Title of the window</param>
    /// <param name="message">Message inside the window</param>
    /// <param name="yesEvent">Callback function of yesButton</param>
    /// <param name="yesParameter">Parameter should be passed to the yesButton's callback function</param>
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
    /// <summary>
    /// Show and customize the popup window's title, message, yesButton's callback function and noButton's callback function
    /// </summary>
    /// <param name="title">Title of the window</param>
    /// <param name="message">Message inside the window</param>
    /// <param name="yesEvent">Callback function of yesButton</param>
    /// <param name="noEvent">Callback function of noButton</param>
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
    /// <summary>
    /// Close(hide) the poped up window
    /// </summary>
    void closePanel()
    {
        this.gameObject.SetActive(false);
    }
}