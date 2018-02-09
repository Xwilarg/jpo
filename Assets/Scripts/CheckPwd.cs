using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CheckPwd : MonoBehaviour
{

    private List<triggerColor.color> pwd;
    private int indexPwd;

    public Material screenOk, screenFail, screenOff, screenLog;
    public MeshRenderer screen;
    public AudioSource source;
    public VideoPlayer player;

    private static Material failScreen;
    
    private bool isOn;
    private bool isLock;

    void Start()
    {
        isOn = true;
        failScreen = screenFail;
        init();
    }

    private void init()
    {
        isLock = true;
        pwd = new List<triggerColor.color>();
        indexPwd = 1;
    }

    public abstract class UsbKey
    {
        public UsbKey(Material image)
        {
            m_image = image;
        }

        public abstract void display(MeshRenderer ms, AudioSource source, VideoPlayer video);
        public abstract AudioClip GetAudioClip();
        public abstract VideoClip GetVideoClip();

        protected Material m_image { private set; get; }
    }

    public class UsbMusic : UsbKey
    {
        public UsbMusic(Material image, AudioClip clip) : base(image)
        {
            m_clip = clip;
        }

        public override void display(MeshRenderer ms, AudioSource source, VideoPlayer video)
        {
            ms.material = m_image;
            source.clip = m_clip;
            source.Play();
        }

        public override AudioClip GetAudioClip()
        {
            return (m_clip);
        }

        public override VideoClip GetVideoClip()
        {
            return (null);
        }

        private AudioClip m_clip;
    }

    public class UsbText : UsbKey
    {
        public UsbText(string pwd) : base(failScreen)
        {
            this.pwd = pwd;
        }

        public override void display(MeshRenderer ms, AudioSource source, VideoPlayer video)
        {
            ms.material = m_image;
        }

        public override AudioClip GetAudioClip()
        {
            return (null);
        }

        public override VideoClip GetVideoClip()
        {
            return (null);
        }

        string pwd;
    }

    public class UsbVideo : UsbKey
    {
        public UsbVideo(Material image, VideoClip clip) : base(image)
        {
            m_clip = clip;
        }

        public override void display(MeshRenderer ms, AudioSource source, VideoPlayer video)
        {
            video.url = "Assets/Licence/" + m_clip.name + ".mp4";
            video.Play();
        }

        public override AudioClip GetAudioClip()
        {
            return (null);
        }

        public override VideoClip GetVideoClip()
        {
            return (m_clip);
        }

        private VideoClip m_clip;
    }

    public void display(UsbKey usb)
    {
        if (!isLock)
        {
            stop();
            usb.display(screen, source, player);
        }
    }

    private void stop()
    {
        source.clip = null;
        player.clip = null;
        source.Stop();
        player.Stop();
    }

    public void unDisplay()
    {
        if (!isLock)
        {
            stop();
            screen.material = screenOk;
        }
    }

    public void switchOnOff(bool value)
    {
        isOn = value;
        if (isOn)
        {
            screen.material = screenLog;
            init();
        }
        else
        {
            screen.material = screenOff;
            stop();
        }
    }

    public void changeVideo(triggerColor.color key)
    {
        if (!isLock && player)
        {
            float framerate = player.frameRate;
            float tojump = framerate * 5;

            if (key == triggerColor.color.PINK)
            {
                if (source.volume > 0)
                    source.volume -= 0.1f;
            }
            else if (key == triggerColor.color.YELLOW)
            {
                if (source.volume < 0)
                    source.volume += 0.1f;
            }
            else if (key == triggerColor.color.RED)
            {
                if (player.isPlaying)
                {
                    player.Pause();
                }
                else
                    player.Play();
            }
            else if (key == triggerColor.color.BLUE && (player.frame - (long)tojump > 0))
                player.frame -= (long)tojump;
            else if (key == triggerColor.color.GREY && ((ulong)(player.frame + (long)tojump) < player.frameCount))
                player.frame += (long)tojump;
            else if (key == triggerColor.color.GREEN)
            {
                if (!source.mute)
                    source.mute = true;
                else
                    source.mute = false;
            }
        }
    }
    public void changeVolume(triggerColor.color key)
    {
        if (!isLock && source)
        {
            if (key == triggerColor.color.YELLOW)
            {
                if (source.volume < 1)
                    source.volume += 0.1f;
            }
            else if (key == triggerColor.color.PINK)
            {
                if (source.volume > 0)
                    source.volume -= 0.1f;
            }
            else if (key == triggerColor.color.RED)
            {
                if (source.isPlaying)
                    source.Pause();
                else
                    source.UnPause();
            }
        }
    }
    public void increasePwd(triggerColor.color key)
    {
        if (!isOn || !isLock || indexPwd == 5) return;
        pwd.Add(key);
        if (indexPwd == 4)
        {
            if (pwd[0] == triggerColor.color.GREEN
                && pwd[1] == triggerColor.color.PINK
                && pwd[2] == triggerColor.color.BLUE
                && pwd[3] == triggerColor.color.RED)
            {
                screen.material = screenOk;
                isLock = false;
            }
            else
                screen.material = screenFail;
        }
        else
            indexPwd++;
    }
}
