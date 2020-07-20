using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background1;
    [SerializeField] private SpriteRenderer _background2;
    [SerializeField] private float _parallaxVelocity = 5;
    void Start()
    {
        _background1.transform.position = Vector3.zero;
        _background2.transform.position = new Vector3(_background2.size.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _background1.transform.position =
            new Vector3(
                _background1.transform.position.x - _parallaxVelocity * Time.deltaTime,
                0,
                0
            );
        _background2.transform.position =
            new Vector3(
                _background2.transform.position.x - _parallaxVelocity * Time.deltaTime,
                0,
                0
            );

        if (_background1.transform.position.x <= -_background1.size.x)
        {
            _background1.transform.position = new Vector3(
                _background1.size.x, 0, 0
            );
            _background2.transform.position = Vector3.zero;
        }
        if (_background2.transform.position.x <= -_background2.size.x)
        {
            _background2.transform.position = new Vector3(
                _background2.size.x, 0, 0
            );
            _background1.transform.position = Vector3.zero;
        }
    }
}
