using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartVideoOutro : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath,"DreamPlanetEndingNew_2.mp4");
    }
}
