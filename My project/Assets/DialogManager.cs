using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public int startMenu;

    Message[] currentMessages;
    Actor[] currentActors;
    public int activeMessage = 0;

    public static bool isActive = false;
    public static bool okNext = false;

    public float textSpeed;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = false;
        okNext = false;

        Debug.Log("Started the conversation ! Loaded messages : " + messages.Length);
        activeMessage = 0;
        DisplayMessage();

        backgroundBox.LeanScale(Vector3.one, 0.5f);
        isActive = true;
        
    }

    void DisplayMessage()
    {
        messageText.text = string.Empty;
        okNext = false;
        Message messageToDisplay = currentMessages[activeMessage];
        
        //messageText.text = messageToDisplay.message;


        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        StartCoroutine(TypeLine(messageToDisplay));

        AnimateTextColor();
        Debug.Log("Message animated");
        okNext = true;
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        } else
        {
            Debug.Log("Conversation ended !");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
            okNext = false;
            if (startMenu == 0)
            {
                SceneManager.LoadScene("Intro");
            }
            if (startMenu == 1)
            {
                SceneManager.LoadScene("Jeu");
            }
            if (startMenu == 2)
            {
                SceneManager.LoadScene("Menu");
            }

            if (startMenu == 3)
            {
                SceneManager.LoadScene("Menu_eng");
            }
            if (startMenu == 4)
            {
                SceneManager.LoadScene("Intro_eng");
            }
            if (startMenu == 5)
            {
                SceneManager.LoadScene("Jeu_eng");
            }

            if (startMenu == 6)
            {
                SceneManager.LoadScene("Menu_esp");
            }
            if (startMenu == 7)
            {
                SceneManager.LoadScene("Intro_esp");
            }
            if (startMenu == 8)
            {
                SceneManager.LoadScene("Jeu_esp");
            }
        }

    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.3f);

    }

    // Start is called before the first frame update
    void Start()
    {
        messageText.text = string.Empty;
        backgroundBox.transform.localScale = Vector3.zero;
    }

    //Update is called once per frame
    void Update()
    {
        if (isActive == true && okNext == true && Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }
    }

    IEnumerator TypeLine(Message messageToDisplay)
    {
        foreach(char c in messageToDisplay.message.ToCharArray())
        {
            messageText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

}
