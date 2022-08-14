using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed;
    [SerializeField] int seconds;
    private int index;
    private Image TextImage;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
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
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (textComponent.text == lines[index])
        {
            yield return new WaitForSeconds(5);
            NextLine();
        }
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(seconds);
    }

    private void NextLine()
    {
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
    {
        if (other.tag == "Player")
        {
            TextImage.enabled = true;
            textComponent.text = string.Empty;
            anim.SetBool("isIdle", false);
            StartDialogue();
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            TextImage.enabled = false;
            textComponent.text = string.Empty;
            anim.SetBool("isIdle", true);

        }
    }
}
