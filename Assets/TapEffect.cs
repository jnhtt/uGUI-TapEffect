using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    public Camera tapCamera;
    public List<Effect> effectList;

    public void Play(Vector3 pos)
    {
        var eff = GetEffect();
        if (eff != null) {
            eff.transform.position = pos;
            eff.Play();
        }
    }

    public Effect GetEffect()
    {
        foreach (var eff in effectList) {
            if (!eff.IsPlaying()) {
                return eff;
            }
        }

        return null;
    }
}
