using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ObjectoTexto")]
public class script_level : ScriptableObject
{
    [TextArea(3, 15)]
    public string textoNarrativo;

    [Space(20)]
    public string respuestaUno;
    public string respuestaDos;
    public string respuestaTres;
    public string respuestaCuatro;

    [Space(20)]
    public float pesoR1;
    public float pesoR2;
    public float pesoR3;
    public float pesoR4;

    [Space(20)]
    public int[] arrayReferencias = new int[4];

    [Space(20)]
    public bool quitaBotones;

    public Sprite image;
    public GameObject personaje;
}
