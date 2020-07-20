using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _velocity = 5f;
    [SerializeField] Camera cam;
    [SerializeField] float _verticalOffset = 20f;
    [SerializeField] float _horizontalOffset = 15f;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float _h = Input.GetAxisRaw("Horizontal");
        float _v = Input.GetAxisRaw("Vertical");
        Vector3 _directionNormalized = (new Vector3(_h, _v, 0)).normalized;
        transform.Translate(_directionNormalized * _velocity * Time.deltaTime);

        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        float posX = Mathf.Clamp(screenPos.x, 0 + _horizontalOffset, Screen.width - _horizontalOffset);
        float posY = Mathf.Clamp(screenPos.y, 0 + _verticalOffset, Screen.height - _verticalOffset);

        Vector3 newPos = cam.ScreenToWorldPoint(new Vector2(posX, posY));
        transform.position = new Vector2(newPos.x, newPos.y);
    }

}
