using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image imageComponent;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Sprite[] images;
    public string[] lines;
    public float textSpeed = 15f;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        imageComponent.sprite = images[0];
        StartDialogue();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (textComponent.text == lines[index])
            {
                PlaySound();
                NextLine();
            }
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    void StartDialogue()
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
    }

    void PlaySound()
    {
        if (audioClips.Length > index)
        {
            audioSource.PlayOneShot(audioClips[index]);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text += string.Empty;
            imageComponent.sprite = images[index];
            audioSource.Stop();
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
