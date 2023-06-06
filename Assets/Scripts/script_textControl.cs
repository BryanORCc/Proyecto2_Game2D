using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class script_textControl : MonoBehaviour
{
    [SerializeField] script_level plantilla;
    [SerializeField] script_level[] arrayPlantillas;

    [SerializeField] TextMeshProUGUI textoNarracion;
    [SerializeField] TextMeshProUGUI textoRespuestaUno;
    [SerializeField] TextMeshProUGUI textoRespuestaDos;
    [SerializeField] TextMeshProUGUI textoRespuestaTres;
    [SerializeField] TextMeshProUGUI textoRespuestaCuatro;
    private Sprite image;
    private GameObject character;

    [SerializeField] GameObject[] arrayBotones;

    // Start is called before the first frame update
    void Start()
    {
        plantilla = arrayPlantillas[0];
        MuestraTexto();
    }

    void MuestraTexto()
    {
        textoNarracion.text = plantilla.textoNarrativo;
        textoRespuestaUno.text = plantilla.respuestaUno;
        textoRespuestaDos.text = plantilla.respuestaDos;
        textoRespuestaTres.text = plantilla.respuestaTres;
        textoRespuestaCuatro.text = plantilla.respuestaCuatro;
        image = plantilla.image;
        character = plantilla.personaje;

        GameObject objetoConEtiqueta = GameObject.FindWithTag("ImageInScene");
        GameObject objetoPersonaje = GameObject.FindWithTag("Character");

        // Asignar la imagen al componente de imagen
        Image imageComponent = objetoConEtiqueta.GetComponent<Image>();
        imageComponent.sprite = image;

        // Asignar el objeto 3d al GameObject
        GameObject characterComponent = Instantiate(character, objetoPersonaje.transform.position, objetoPersonaje.transform.rotation);
        characterComponent.transform.localScale = new Vector3(3f, 3f, 3f);
        characterComponent.transform.parent = objetoPersonaje.transform;
    }

    public void ControlBotones (int indice)
    {
        plantilla = arrayPlantillas[plantilla.arrayReferencias[indice]];

        if (plantilla.quitaBotones == true)
        {
            DesactivaBotones();
        }
        MuestraTexto();
    }

    void DesactivaBotones()
    {
        foreach(var boton in arrayBotones)
        {
            boton.SetActive(false);
        }
    }
}
