using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    public GameObject esfera, cilindro;
    private int state;
    private void Start()
    {
        state = 0;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            switch (state)
            {
                case 0:
                    esfera.SetActive(false);
                    state = 1;
                    break;
                case 1:
                    cilindro.SetActive(false);
                    state = 2;
                    break;
                case 2:
                    esfera.SetActive(true);
                    cilindro.SetActive(true);
                    state = 0;
                    break;
            }
        }
    }
}
