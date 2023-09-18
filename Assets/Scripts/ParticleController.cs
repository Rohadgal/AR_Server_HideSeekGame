using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particles;

    private void Start() {
        particles = GetComponent<ParticleSystem>();
    }

    public void PlayParticles() {
        particles.Play();
    }

    public void StopParticles() {
        particles.Stop();
    }
}
