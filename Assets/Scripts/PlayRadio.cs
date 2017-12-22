using UnityEngine;

public class PlayRadio : MonoBehaviour {
    
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "UsbKey")
        {
            source.clip = other.GetComponent<UsbContent>().key.GetAudioClip();
            source.Play();
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
