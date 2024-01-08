using UnityEngine;
using System.Collections.Generic;

public class Barrel : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                barrels.Add(hit.attachedRigidbody);

        }
         
        return barrels;
    }
}