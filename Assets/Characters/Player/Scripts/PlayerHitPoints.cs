using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints : MonoBehaviour {

    public float HitPoints = 100;
    public float HitEffectTimeInSections = 3.3f;
    
    private CanvasGroup _hitCanvasGroup;
    private volatile bool isPlayingAffect;

    // Use this for initialization
    void Start () {
        _hitCanvasGroup = transform.Find("HitCanvas").GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Strike(float damage)
    {
        HitPoints -= damage;

        if (HitPoints <= 0)
            Die();

        if (!isPlayingAffect)
        {
            var fadeIn = Time.time + (HitEffectTimeInSections / 2);
            var fadeOut = fadeIn + (HitEffectTimeInSections / 2);

            isPlayingAffect = true;
            StartCoroutine(PlayHitEffect(fadeIn, fadeOut));
        }
    }

    IEnumerator PlayHitEffect(float fadeIn, float fadeOut)
    {
        while (isPlayingAffect)
        {
            if (Time.time <= fadeIn)
                _hitCanvasGroup.alpha += Mathf.Lerp(0f, 0.3f, (HitEffectTimeInSections / 2));
            else if (Time.time <= fadeOut)
                _hitCanvasGroup.alpha -= Mathf.Lerp(0f, 0.3f, (HitEffectTimeInSections / 2));
            else
            {
                _hitCanvasGroup.alpha = 0;
                isPlayingAffect = false;
            }

            yield return new WaitForEndOfFrame();
        }

        yield return 0;

    }
    
    void Die()
    {

    }
}
