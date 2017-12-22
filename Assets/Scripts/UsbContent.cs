using System;
using UnityEngine;
using UnityEngine.Video;

public class UsbContent : MonoBehaviour {


    public enum UsbType
    {
        UsbAudio,
        UsbVideo
    }

    public CheckPwd.UsbKey key { private set; get; }
    public UsbType type;
    public AudioClip clip;
    public Material mat;
    public VideoClip video;

    void Start () {
        if (type == UsbType.UsbAudio)
            key = new CheckPwd.UsbMusic(mat, clip);
        else if (type == UsbType.UsbVideo)
            key = new CheckPwd.UsbVideo(mat, video);
        else
            throw new ArgumentException("type doesn't have a valid value.");
	}
}
