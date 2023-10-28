using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [Range(0,10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,0.2f)]
    [SerializeField] float dustFormationPeriod;

    public void MovementPlay () 
    {
        movementParticle.Play();
    }
         
}
