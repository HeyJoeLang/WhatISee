using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {

    public PlayerOverlay overlay;
    public AudioClip clip;
    public Button[] buttons;
    public void Load(int level)
    {
        StartCoroutine(FadeThenLoad(level));
    }
    IEnumerator FadeThenLoad(int level)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].GetComponent<Image>().raycastTarget = false;
        }
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        overlay.TriggerFadeIn();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(level);
    }
}
