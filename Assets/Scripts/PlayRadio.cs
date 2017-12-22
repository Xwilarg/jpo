using UnityEngine;
using UnityEngine.Video;

public class PlayRadio : MonoBehaviour {
    
    private AudioSource source;
    private VideoPlayer player;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        player = GetComponentInChildren<VideoPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "UsbKey")
        {
            UsbContent usb = other.GetComponent<UsbContent>();
            AudioClip ac = usb.key.GetAudioClip();
            if (ac != null)
            {
                source.clip = ac;
                source.Play();
            }
            else
            {
                player.url = "Assets/Licence/" + usb.key.GetVideoClip().name + ".mp4";
                player.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "UsbKey")
        {
            source.clip = null;
            source.Stop();
        }
    }
}
