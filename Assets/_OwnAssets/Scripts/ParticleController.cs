using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;

    public float speed;
    public float lifetime;
    public float emissionSpeed;
    public float randomizePosition;
    public float noise;

    // Update is called once per frame
    void Update()
    {
        if (particle1.velocityOverLifetime.speedModifierMultiplier != speed ||
            particle1.main.startLifetime.constant != lifetime ||
            particle1.emission.rateOverTimeMultiplier != emissionSpeed ||
            particle1.shape.randomPositionAmount != randomizePosition ||
            particle1.noise.positionAmount.constant != noise)
        {
            updateParticles(particle1);
            updateParticles(particle2);
            updateParticles(particle3);
        }
    }

    private void updateParticles(ParticleSystem particle)
    {
        var emission = particle.emission;
        emission.rateOverTime = emissionSpeed;

        var main = particle.main;
        main.startLifetime = lifetime;

        var velocityOverLifetime = particle.velocityOverLifetime;
        velocityOverLifetime.speedModifierMultiplier = speed;

        var shape = particle.shape;
        shape.randomPositionAmount = randomizePosition;

        var particleNoise = particle.noise;
        particleNoise.positionAmount = noise;
    }
}
