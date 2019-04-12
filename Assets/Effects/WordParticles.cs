using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordParticles : MonoBehaviour
{
    ParticleSystem particles;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.MinMaxCurve rateCurve;
    [SerializeField] TMP_InputField answer;


    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        rateCurve = particles.emission.rateOverTime;
        emissionModule = particles.emission;
        StartCoroutine(SetParticleEmission());
    }

    IEnumerator SetParticleEmission()
    {
        while (true)
        {
            string[] split = answer.text.Split(' ');
            rateCurve.constant = split.Length / particles.main.startLifetime.constant;
            emissionModule.rateOverTime = rateCurve;

            yield return new WaitForSeconds(1);

        }

    }
}
