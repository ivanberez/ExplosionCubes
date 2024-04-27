using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SpawnerCoubs))]
public class Coub : MonoBehaviour
{
    [SerializeField] private float _forceExplosion;
    [SerializeField] private float _radiusExplosion;
    
    private SpawnerCoubs _spawner;
    private int _chanceSeparation = 100;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _spawner = GetComponent<SpawnerCoubs>();
        Rigidbody = GetComponent<Rigidbody>();        
    }

    private void OnMouseUpAsButton()
    {
        if (_spawner.TrySpawn(out Coub[] coubs, _chanceSeparation))
            ScatterCoubs(coubs);

        Destroy(gameObject);
    }

    public void Init(Vector3 scale, int chanceSeparation)
    {
        transform.localScale = scale;
        _chanceSeparation = chanceSeparation;
    }

    private void ScatterCoubs(Coub[] coubs)
    {
        foreach (Coub coub in coubs)
            coub.Rigidbody.AddExplosionForce(_forceExplosion, transform.position, _radiusExplosion);
    }
}
