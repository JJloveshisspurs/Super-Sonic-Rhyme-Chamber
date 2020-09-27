using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicController : MonoBehaviour
{
    public bool randomizeStartingSong;

    public AudioSource musicAudioSource;
    public List<MusicData> musicSamples = new  List<MusicData>();

    public TextMeshProUGUI musicTitle;


    private int songIndex;



    public void Start()
    {
        if(randomizeStartingSong)
        PlayRandomSong();
    }

    public void PlayPreviousSong()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Stop();
            musicAudioSource = null;
        }

        songIndex--;
        if (songIndex < 0)
            songIndex = musicSamples.Count - 1;

        musicTitle.text = musicSamples[songIndex].songName;
        musicAudioSource.clip = musicSamples[songIndex].songAudio;
        musicAudioSource.Play();

    }

    public void PlayNextSong()
    {

        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Stop();
            musicAudioSource = null;
        }
       

        songIndex++;

        if (songIndex > musicSamples.Count)
            songIndex = 0;

        musicTitle.text = musicSamples[songIndex].songName;
        musicAudioSource.clip = musicSamples[songIndex].songAudio;
        musicAudioSource.Play();

    }

    public void PlayRandomSong()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Stop();
            musicAudioSource = null;
        }

        songIndex = Random.Range(0, musicSamples.Count);

        musicTitle.text = musicSamples[songIndex].songName;
        musicAudioSource.clip = musicSamples[songIndex].songAudio;

        musicAudioSource.Play();

    }
}
