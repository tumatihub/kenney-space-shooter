using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] Meteor[] _meteorParts;
    [SerializeField] Vector2 _direction = new Vector2(-1, 0);
    [SerializeField] float _verticalDirectionOffset = 1f;
    [SerializeField] float _velocity = 2f;
    [SerializeField] float _rotationVelocity = 20f;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        SetDirection(_direction);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.rotation += _rotationVelocity * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            SplitMeteorParts();
        }    
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        _rigidbody.velocity = direction * _velocity;
    }

    void SplitMeteorParts()
    {
        foreach (var part in _meteorParts)
        {
            Debug.Log("Setting " + part.name);
            var instance = Instantiate(part, transform.position, Quaternion.identity) as Meteor;
            instance.SetDirection(new Vector2(_direction.x, Random.Range(-_verticalDirectionOffset, _verticalDirectionOffset)).normalized);
        }

        Destroy(gameObject);
    }
}
