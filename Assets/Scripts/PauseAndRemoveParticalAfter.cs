using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class PauseAndRemoveParticalAfter : MonoBehaviour
{
    public ParticleSystem pauseParticle;
    public ParticleSystem removeParticle;

    public float secondsForPause;
    public float secondsForRemove;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Pause());
    }

    public IEnumerator Pause()
    {
        yield return new WaitForSeconds(secondsForPause);
        if (!pauseParticle.isPaused)
        {
            pauseParticle.Pause(true);
        }
        //pause
        yield return new WaitForSeconds(secondsForRemove);
        //remove
        removeParticle.Stop();
        removeParticle.Clear();
        Destroy(removeParticle.gameObject);
    }
}
