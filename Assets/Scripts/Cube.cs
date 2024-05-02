using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SpawnerCubes))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _forceExplosion;
    [SerializeField] private float _radiusExplosion;
    
    private SpawnerCubes _spawner;
    private int _chanceSeparation = 100;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _spawner = GetComponent<SpawnerCubes>();
        Rigidbody = GetComponent<Rigidbody>();        
    }

    private void OnMouseUpAsButton()
    {
        if (_spawner.TrySpawn(out Cube[] cubes, _chanceSeparation))
            ScatterCoubs(cubes);

        Destroy(gameObject);
    }

    public void Init(Vector3 scale, int chanceSeparation)
    {
        transform.localScale = scale;
        _chanceSeparation = chanceSeparation;
    }

    private void ScatterCoubs(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
            cube.Rigidbody.AddExplosionForce(_forceExplosion, transform.position, _radiusExplosion);
    }
}
