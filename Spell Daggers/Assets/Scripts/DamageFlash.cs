using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public List<ColourLerp> colourTransitions;

    private Image damageFlash = null;
    private bool isTransitioning = false;
    private float transitionTimer = 0;
    private int colourCount;

	// Use this for initialization
	void Start ()
    {
        damageFlash = GetComponentInChildren<Image>();
	}

    private void Update()
    {
        if (isTransitioning)
        {
            if (colourCount == colourTransitions.Count - 1)
            {
                float t = transitionTimer / colourTransitions[colourCount].lerpTime;

                Color fadeOut = colourTransitions[colourCount].colour;
                fadeOut.a = 0;

                damageFlash.color = Color.Lerp(colourTransitions[colourCount].colour, fadeOut, t);
            }
            else
            {
                float t = transitionTimer / colourTransitions[colourCount].lerpTime;

                damageFlash.color = Color.Lerp(colourTransitions[colourCount].colour, colourTransitions[colourCount + 1].colour, t);
            }

            transitionTimer += Time.deltaTime;

            if (transitionTimer > colourTransitions[colourCount].lerpTime)
            {
                transitionTimer -= colourTransitions[colourCount].lerpTime;
                ++colourCount;

                if (colourCount == colourTransitions.Count)
                    isTransitioning = false;
            }
        }
    }

    public void StartDamageFlash()
    {
        if (colourTransitions.Count <= 0)
        {
            Debug.Assert(false, "Damage flash has no colours");
            return;
        }

        damageFlash.color = colourTransitions[0].colour;

        transitionTimer = 0;
        colourCount = 0;

        isTransitioning = true;
    }

    [System.Serializable]
    public struct ColourLerp
    {
        public Color colour;
        [Tooltip("How long it takes to transition to the next colour, in seconds.")]
        public float lerpTime;
    }
}
