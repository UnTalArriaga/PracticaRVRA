using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void C_Escena(string N_Escena)
    {
        SceneManager.LoadScene(N_Escena);
    }
}
