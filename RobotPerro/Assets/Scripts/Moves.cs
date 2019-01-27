﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{

    public float distance;
    public int puntos;
    public int descontarVidaCantidad = 10;

    private vida refVida;
    public Score refScore;

    private void Start()
    {
        refVida = GetComponent<vida>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.z < 2.93)

        {
            transform.position = new Vector3(0, 0, distance + transform.position.z);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.z > 1.33)

        {
            transform.position = new Vector3(0, 0, -distance + transform.position.z);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstaculos":
                print(collision.gameObject.name);
                refVida.DescontarVida(descontarVidaCantidad);
                Destroy(collision.gameObject);
                break;
            case "SafePath":
                refScore.SumarPuntos(10);
                break;
            default:
                Debug.Log("Chocaste con algo desconocido");
                break;
        }

    }
}
