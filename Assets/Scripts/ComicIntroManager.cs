using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComicIntroManager : MonoBehaviour {

    public List<AudioClip> audioClips;
    AudioSource audioSource;
    Image image;

    public List<Sprite> images;

    int current = 0;

    public ImageFade fade;
    bool next = true;

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();

        fade = GameObject.FindObjectOfType<ImageFade>();

        SetIntro(current);
    }
	
	// Update is called once per frame
	void Update () {


        if (!audioSource.isPlaying)
        {
            if (current >= 9)
            {

                SceneManager.LoadScene("Level21");
                return;
            }
            else
            {
                if (next && current < 9)
                {
                    current++;
                    next = false;
                    StartCoroutine(NextIntro());
                    
                    
                }
            }
        }
    }

    void SetIntro(int i)
    {
        audioSource.clip = audioClips[i];
        image.sprite = images[i];


        audioSource.PlayDelayed(2f);
    }


    IEnumerator WaitFade()
    {

        fade.startfade = true;
        fade.fadeaway = false;
        yield return new WaitForSeconds(1f);

        fade.startfade = true;
        fade.fadeaway = true;
        
        
    }

    IEnumerator NextIntro()
    {
        yield return WaitFade();
        yield return  new WaitForSeconds(1f);
        next = true;
        SetIntro(current);

    }

  

}
