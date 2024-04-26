using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource mainOst;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource locker;
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource lose;
    [SerializeField] private AudioSource menue;

    public void OpenLocker()
    {
        locker.Play();
    }

    public void PlayButton()
    {
        button.Play();
    }
    public void Win ()
    {
        lose.Stop();

        win.Stop();

        menue.Stop();

        mainOst.Stop();

        win.Play();
    }
    public void Lose()
    {
        lose.Stop();

        win.Stop();

        menue.Stop();

        mainOst.Stop();

        lose.Play();
    }

    public void Main()
    {
        lose.Stop();

        win.Stop();

        menue.Stop();

        mainOst.Stop();

        mainOst.Play();
    }

    public void Menue()
    {
        lose.Stop();

        win.Stop();

        menue.Stop();

        mainOst.Stop();

        menue.Play();
    }
}
