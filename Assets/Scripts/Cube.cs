using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField, Min(1)] private float _forceExplosion;
    [SerializeField, Min(1)] private float _radiusExplosion;

    private SpawnerCubes _spawner;
    private int _chanceSeparation = 100;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {        
        Rigidbody = GetComponent<Rigidbody>();
        
        if(_spawner == null)
            _spawner = FindAnyObjectByType<SpawnerCubes>();
    }

    private void OnMouseUpAsButton()
    {
        if (_spawner.TrySpawn(out Cube[] cubes, _chanceSeparation, transform))
            ScatterCoubs(cubes);
        else
            Blow();

        Destroy(gameObject);
    }

    public void Init(Vector3 scale, int chanceSeparation)
    {
        transform.localScale = scale;
        _chanceSeparation = chanceSeparation;

        float dividerExplosion = scale.magnitude;        

        _forceExplosion = _forceExplosion / dividerExplosion;
        _radiusExplosion = _radiusExplosion / dividerExplosion;
    }

    private void ScatterCoubs(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
            cube.Rigidbody.AddForceAtPosition(Vector3.one, transform.position);
    }

    private void Blow()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radiusExplosion);

        foreach (Collider hit in hits)
            hit.attachedRigidbody?.AddExplosionForce(_forceExplosion, transform.position, _radiusExplosion, 1f, ForceMode.Impulse);
    }
}
