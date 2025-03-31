using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem),typeof(Collider))]

public class ParticleTrigger : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public int firstEmissionAmount = 10;
    public int secondEmissionAmount = 20;
    public int thirdEmissionAmount = 30;
    public float delayBetweenEmissions = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterController>())
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        // First Emission
        particleSystem.Emit(firstEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);

        // Second Emission
        particleSystem.Emit(secondEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions); // Wait

        // Third Emission
        particleSystem.Emit(thirdEmissionAmount);
    }
}
