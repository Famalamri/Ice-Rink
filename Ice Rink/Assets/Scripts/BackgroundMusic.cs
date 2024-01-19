using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;

        //fade in and out
        StartCoroutine(Fade(true, source, 2f, 1f));
        StartCoroutine(Fade(false, source, 2f, 0f));
    }

    public IEnumerator Fade(bool fadeIn,AudioSource source, float duration, float targetVolume)
    {
        if (!fadeIn)
        {
            //calculate clip length
            double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)lengthOfSource - duration);
        }

        float time = 0f;
        float startVol = source.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }
    }
}
