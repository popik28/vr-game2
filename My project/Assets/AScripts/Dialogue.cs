using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{/// <summary>Handles NPC dialogue to point the player to the next objective</summary>
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed;
    [SerializeField] int seconds;
    private int index;
    private Image TextImage;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {   /// <summary>Initializes animator and text components.</summary>
        anim = this.GetComponentInParent<Canvas>().GetComponentInParent<Animator>();
        TextImage = this.GetComponent<Image>();
        TextImage.enabled = false;
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach (char c in lines[index].ToCharArray()) 
        {/// <summary>Function types the line, one character at a time from array of dialogue strings.</summary>
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (textComponent.text == lines[index])
        {/// <summary>If we have reached end of line continue to next line, else do nothing.</summary>
            yield return new WaitForSeconds(5);
            NextLine();
        }
    }

    IEnumerator WaitSeconds()
    {   /// <summary>Enumerator to handle time delay</summary>
        yield return new WaitForSeconds(seconds);
    }

    private void NextLine()
    {   /// <summary>Handles next line in array, if last line has been written, destroy game object.</summary>
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {   /// <summary>Activate textbox when player interacts with NPC and handle animation</summary>
        if (other.tag == "Player")
        {
            TextImage.enabled = true;
            textComponent.text = string.Empty;
            anim.SetBool("isIdle", false);
            StartDialogue();
         
        }
    }

    private void OnTriggerExit(Collider other)
    {   /// <summary>Stop coroutines and disable text & textbox</summary>
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            TextImage.enabled = false;
            textComponent.text = string.Empty;
            anim.SetBool("isIdle", true);

        }
    }
}
