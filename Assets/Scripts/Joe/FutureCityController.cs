using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FutureCity
{
    public Material skybox;
    public Canvas[] userInterfaces;
}
public class FutureCityController : MonoBehaviour
{
    public FutureCity[] futureCities;
    public Button[] buttons;
    public LoadScene loadScene;
    public AudioSource source;
    public bool hasSkipped = false;

    public void LoadFutureCity(int index)
    {
        StartCoroutine(LoadFuture(index));
    }
    IEnumerator LoadFuture(int index)
    {
        loadScene.overlay.TriggerFadeIn();
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < futureCities.Length; i++)
            for(int j = 0; j < futureCities[i].userInterfaces.Length; j++)
                futureCities[i].userInterfaces[j].gameObject.SetActive(false);
        for(int i = 0; i < futureCities[index].userInterfaces.Length; i++)
            futureCities[index].userInterfaces[i].gameObject.SetActive(true);
        RenderSettings.skybox = futureCities[index].skybox;
        loadScene.overlay.TriggerFadeout();
    }
    public void Skip()
    {
        hasSkipped = true;
        ToggleButtons(true);
        StopCoroutine("StallForLectureToFinish");
    }
    public void SetClip(AudioClip clip)
    {
        source.clip = clip;
    }
    public void SelectButton(Button button)
    {
        ToggleButtons(false);
        button.interactable = true;
        button.GetComponent<Image>().raycastTarget = false;
        if (button.tag == "EndLevel")
            EndLevel();
        else
            StartCoroutine("StallForLectureToFinish");

        Animator animator = button.GetComponent<Animator>();
        if (animator != null)
            animator.Play("Activated");
    }
    public void ToggleButtons(bool toggle)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Animator animator = buttons[i].GetComponent<Animator>();
            if (animator != null)
                animator.Play("Deactivated");
            buttons[i].interactable = toggle;
            buttons[i].GetComponent<Image>().raycastTarget = toggle;
        }
    }
    void EndLevel()
    {
        loadScene.buttons = buttons;
        loadScene.Load(0);
    }
    IEnumerator StallForLectureToFinish()
    {
        yield return new WaitForSeconds(.25f);
        source.PlayOneShot(source.clip);
        yield return new WaitForSeconds(source.clip.length + .5f);
   
            ToggleButtons(true);
    }
}