using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleEffect;
    [SerializeField]
    private bool isBillboard;

    public void Play()
    {
        if (particleEffect != null) {
            particleEffect.Play();
        }
    }

    public void Stop()
    {
        if (particleEffect != null) {
            particleEffect.Stop();
        }
    }

    public bool IsPlaying()
    {
        if (particleEffect != null) {
            return particleEffect.isPlaying;
        }
        return false;
    }

    private void Update()
    {
        if (isBillboard) {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}