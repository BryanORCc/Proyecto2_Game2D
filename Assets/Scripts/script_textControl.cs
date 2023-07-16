using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script_textControl : MonoBehaviour
{
    public static script_textControl instance;

    [SerializeField] script_level plantilla;
    [SerializeField] script_level[] arrayPlantillas;

    [SerializeField] TextMeshProUGUI textoNarracion;
    [SerializeField] TextMeshProUGUI textoRespuestaUno;
    [SerializeField] TextMeshProUGUI textoRespuestaDos;
    [SerializeField] TextMeshProUGUI textoRespuestaTres;
    [SerializeField] TextMeshProUGUI textoRespuestaCuatro;

    private Sprite image;
    private GameObject character;
    private GameObject character2;
    private float[] pesos;

    public float nota = 0;

    [SerializeField] GameObject[] arrayBotones;

    // Start is called before the first frame update
    void Start()
    {
        ReiniciarPlantilla();
        MuestraTexto();
    }

    void MuestraTexto()
    {
        textoNarracion.text = plantilla.textoNarrativo;
        textoRespuestaUno.text = plantilla.respuestaUno;
        textoRespuestaDos.text = plantilla.respuestaDos;
        textoRespuestaTres.text = plantilla.respuestaTres;
        textoRespuestaCuatro.text = plantilla.respuestaCuatro;

        pesos = new float[] { plantilla.pesoR1, plantilla.pesoR2, plantilla.pesoR3, plantilla.pesoR4 };

        image = plantilla.image;
        character = plantilla.personaje;
        character2 = plantilla.personaje2;

        GameObject objetoConEtiqueta = GameObject.FindWithTag("ImageInScene");
        GameObject objetoPersonaje = GameObject.FindWithTag("Character");
        GameObject objetoPersonaje2 = GameObject.FindWithTag("Character2");

        if (objetoPersonaje != null)
        {
            Transform parentTransform = objetoPersonaje.transform;

            // Iterar sobre cada hijo y destruirlo
            for (int i = parentTransform.childCount - 1; i >= 0; i--)
            {
                Transform child = parentTransform.GetChild(i);
                DestroyImmediate(child.gameObject);
            }
        }

        if (objetoPersonaje2 != null)
        {
            Transform parentTransform = objetoPersonaje2.transform;

            // Iterar sobre cada hijo y destruirlo
            for (int i = parentTransform.childCount - 1; i >= 0; i--)
            {
                Transform child = parentTransform.GetChild(i);
                DestroyImmediate(child.gameObject);
            }
        }

        // Asignar la imagen al componente de imagen
        Image imageComponent = objetoConEtiqueta.GetComponent<Image>();
        imageComponent.sprite = image;

        // Asignar el objeto 3d al GameObject
        if (objetoPersonaje && character)
        {
            Vector3 p1Position = new(plantilla.p1PosicionX * 0.01f, plantilla.p1PosicionY * 0.01f, objetoPersonaje.transform.position.z);
            GameObject characterComponent = Instantiate(character, p1Position, character.transform.rotation);
            characterComponent.transform.localScale = new Vector3(4f, 4f, 4f);
            //characterComponent.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            characterComponent.transform.parent = objetoPersonaje.transform;
        }

        if (objetoPersonaje2 && character2)
        {
            Vector3 p2Position = new(plantilla.p2PosicionX * 0.01f, plantilla.p2PosicionY * 0.01f, objetoPersonaje2.transform.position.z);
            GameObject characterComponent = Instantiate(character2, p2Position, character2.transform.rotation);
            characterComponent.transform.localScale = new Vector3(4f, 4f, 4f);
            //characterComponent.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            characterComponent.transform.parent = objetoPersonaje2.transform;
        }


        foreach (var boton in arrayBotones)
        {
            TextMeshProUGUI textoBoton = boton.GetComponentInChildren<TextMeshProUGUI>();

            if (textoBoton != null && !string.IsNullOrEmpty(textoBoton.text))
            {
                Debug.Log("El botón contiene texto: " + textoBoton.text);
                boton.SetActive(true);
            }
            else
            {
                boton.SetActive(false);
            }
        }
    }

    public void ControlBotones (int indice)
    {
        nota += pesos[indice];

        if (plantilla.arrayReferencias[indice] == 50)
        {
            SceneManager.LoadScene(14);
        } 
        else
        {
            plantilla = arrayPlantillas[plantilla.arrayReferencias[indice]];
            MuestraTexto();
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void ReiniciarPlantilla()
    {
        plantilla = arrayPlantillas[0];
    }
}
