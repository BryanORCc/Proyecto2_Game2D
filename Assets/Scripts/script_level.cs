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

    [Space(20)]
    public int[] arrayReferencias = new int[3];

    [Space(20)]
    public bool quitaBotones;
}
