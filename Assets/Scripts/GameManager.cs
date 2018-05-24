using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Avatar
{
    public float stall;
    public GameObject head;
    public AudioClip vocal;
}

public class GameManager : MonoBehaviour {
    
    public Avatar[] avatars;
    int counter = 0;
    public AudioSource source;
    private void Start()
    {
        source.clip = avatars[counter].vocal;
        source.Play();
    }
    public void NextAvatar()
    {
        source.Stop();
        avatars[counter].head.SetActive(false);
        counter++;
        if (counter == avatars.Length)
        {
            counter = 0;
        }
        StartCoroutine("PlayAvatar");
    }

    public void PreviousAvatar()
    {
        source.Stop();
        avatars[counter].head.SetActive(false);
        counter--;
        if (counter == -1)
        {
            counter = avatars.Length-1;
        }
        StartCoroutine("PlayAvatar");
    }
    IEnumerator PlayAvatar()
    {
        avatars[counter].head.SetActive(true);
        yield return new WaitForSeconds(avatars[counter].stall);
        source.clip = avatars[counter].vocal;
        source.Play();
    }
}
