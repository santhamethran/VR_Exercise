using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class VideoManagement : MonoBehaviour
{

    [SerializeField] private Image muteBtn;
    [SerializeField] private Sprite muteBtnSprite;
    [SerializeField] private Sprite UnmuteBtnSprite;
    public bool IscontrolMute;
    public GameObject btnPlay;
    public GameObject btnPause;
    public Slider SeekBar;

    private bool videoIsJumping = false;
    public bool videoIsPlaying = true;
    private VideoPlayer videoPlayer;


    private void OnEnable()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.SetDirectAudioMute(0, false);
        muteBtn.GetComponent<Image>().sprite = muteBtnSprite;
        videoIsPlaying = true;
        btnPause.SetActive(true);
        btnPlay.SetActive(false);
    }
    private void Start()
    {
       
        // videoPlayer.frame = (long)100;
        //Invoke("StartVideoPlay", 3);
    }

    private void Update()
    {
        if (videoPlayer.frameCount > 0 && !videoIsJumping)
        {
            SeekBar.value = ((float)videoPlayer.frame / (float)videoPlayer.frameCount) * 100;
        }
    }

    public void OnPointerDown()
    {
        videoIsJumping = true;
        VideoStop();
        var frame = (videoPlayer.frameCount * SeekBar.value) / 100;
        videoPlayer.frame = (long)frame;
        SeekBar.value = ((float)videoPlayer.frame / (float)videoPlayer.frameCount) * 100;
    }

    public void OnPointerDrag()
    {
        videoIsJumping = true;
        VideoStop();
        var frame = (videoPlayer.frameCount * SeekBar.value) / 100;
        videoPlayer.frame = (long)frame;
    }

    public void OnPointerUp()
    {
        VideoPlay();
        videoIsJumping = false;
    }

    public void StartVideoPlay()
    {
        VideoPlay();
    }

    public void BtnPlayVideo()
    {
        if (videoIsPlaying)
        {
            VideoStop();
           
        }
        else
        {
            VideoPlay();
            
        }
    }

    private void VideoStop()
    {
        videoIsPlaying = false;
        videoPlayer.Pause();
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    private void VideoPlay()
    {
        videoIsPlaying = true;
        videoPlayer.Play();
        btnPause.SetActive(true);
        btnPlay.SetActive(false);
    }

    public void LoadScene(string scenName)
    {
        SceneManager.LoadScene(scenName);
    }
    public void Mute()
    {
        IscontrolMute = !IscontrolMute;
       
        videoPlayer.SetDirectAudioMute(0, IscontrolMute);
        if (IscontrolMute)
        {
            muteBtn.GetComponent<Image>().sprite = UnmuteBtnSprite;
        }
        else
        {
            muteBtn.GetComponent<Image>().sprite = muteBtnSprite;
        }
      
    }
    private void OnDisable()
    {
        IscontrolMute = false;
       
    }



}
