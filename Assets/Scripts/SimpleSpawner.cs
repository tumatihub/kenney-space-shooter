using TreeEditor;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] int _minHeight = 0;
    [SerializeField] int _maxHeight = 10;
    [SerializeField] float _delay = 5f;
    float _cooldown = 0f;
    [SerializeField] GameObject _prefabToSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        if (_cooldown <= 0)
        {
            Spawn();
            _cooldown = _delay;
        }
        else
        {
            _cooldown -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Instantiate(_prefabToSpawn, new Vector3(transform.position.x, Random.Range(_minHeight, _maxHeight)), Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(
            new Vector3(transform.position.x, _minHeight, transform.position.z),
            new Vector3(transform.position.x, _maxHeight, transform.position.z)
        );
    }
}
