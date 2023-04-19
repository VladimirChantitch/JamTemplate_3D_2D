using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    [SerializeField] Light2D light;

    [SerializeField] float speed;
    [SerializeField] float maxIntensity;

    bool maxReached;
    bool isFlashing = true;

    public void Update()
    {
        if (isFlashing)
        {
            Flash();
        }
    }

    void Flash()
    {
        if (maxReached == false)
        {
            if (light.intensity >= maxIntensity)
            {
                maxReached = true;
            }
            else
            {
                light.intensity += speed;
            }
        }
        else
        {
            light.intensity -= speed;
            if (light.intensity <= 0)
            {
                isFlashing = false;
            }
        }
    }
}
