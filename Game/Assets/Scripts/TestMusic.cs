using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public float[] _samples = new float[512];
    static public float[] _frequencyBands = new float[8];

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GameSettings.getAudio();
        audioSource.Play();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        GetFrequencyBands();
    }

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    private void GetFrequencyBands()
    {
        /**
         * 22050 /512 = 43hertz per sample
         * 20 - 60 hertz
         * 60 - 250 hertz
         * 250 - 500 hertz
         * 500 - 2000 hertz
         * 2000 - 4000 hertz
         * 4000 - 6000 hertz
         * 6000 - 20000 hertz
         * 
         * 0 - 2 = 86 hertz
         * 1 - 4 = 172 hertz - 87-258
         * 3 - 16 = 688 hertz - 259 - 602
         * 2 - 8  = 344 hertz - 603 - 1290
         * 4 - 32 = 1376 hertz - 1291 - 2666
         * 5 - 64 = 2752 hertz - 2667 - 5418
         * 6 - 128 = 5504 hertz - 5419 - 10922
         * 7 - 256 = 11008 hertz - 10923 - 21930
         * 510
         **/

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }

            average /= count;

            _frequencyBands[i] = average * 10;
        }
    }
}
