using UnityEngine;
using UnityEngine.UI;

public class BocadilloPreguntes : MonoBehaviour
{
    public static BocadilloPreguntes instance;

    public Text resposta1;
    public Text resposta2;
    public Text resposta3;
    public Text resposta4;

    private string res1;
    private string res2;
    private string res3;
    private string res4;

    public GameObject posicio1;
    public GameObject posicio2;
    public GameObject posicio3;
    public GameObject posicio4;

    public Image seleccionador;

    public bool allowInput = false;

    public bool canNavigate = true;
    private int respostaCorrecta;
    private int indexPosicio = 1; // seran index 1, 2, 3, i 4, perque hi ha 4 possibles respostes

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        gameObject.SetActive(false);
        resposta1.gameObject.SetActive(false);
        resposta2.gameObject.SetActive(false);
        resposta3.gameObject.SetActive(false);
        resposta4.gameObject.SetActive(false);

        Vector3 positionToSet = posicio1.transform.position;

        // Establecer la posición de la imagen
        seleccionador.rectTransform.position = positionToSet;

        // Desactivar el GameObject de la imagen
        seleccionador.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (TextManager.instance.comptadorProfessor == 4)
        {
            res1 = "1. Celebració tennistaulística";
            res2 = "2. Finestra";
            res3 = "3. Cadira";
            res4 = "4. Ventilador";

            resposta1.text = res1;
            resposta2.text = res2;
            resposta3.text = res3;
            resposta4.text = res4;

            respostaCorrecta = 1;

            if (canNavigate && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                ChangeSelector(Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Verificar si se puede responder
                if (TextManager.instance.allowInput)
                {
                    if (indexPosicio == respostaCorrecta)
                    {
                        PersonajeInteractuable.instance.puedeInteractuar = true;
                        TextManager.instance.allowInput = true;
                        TextManager.instance.comptadorProfessor = 6;
                        // Llamar al método para establecer que la pregunta se ha formulado
                        PersonajeInteractuable.instance.EstablecerPreguntaFormulada();
                    }
                }
            }
        }
        else if (TextManager.instance.comptadorProfessor == 7)
        {
            res1 = "1. ARAM";
            res2 = "2. Socket";
            res3 = "3. Hard Code";
            res4 = "4. MongoDB";

            resposta1.text = res1;
            resposta2.text = res2;
            resposta3.text = res3;
            resposta4.text = res4;

            respostaCorrecta = 3;

            if (canNavigate && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                ChangeSelector(Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Verificar si se puede responder
                if (TextManager.instance.allowInput)
                {
                    if (indexPosicio == respostaCorrecta)
                    {
                        PersonajeInteractuable.instance.puedeInteractuar = true;
                        TextManager.instance.allowInput = true;
                        TextManager.instance.comptadorProfessor = 9;
                        // Llamar al método para establecer que la pregunta se ha formulado
                        PersonajeInteractuable.instance.EstablecerPreguntaFormulada();
                    }
                }
            }
        }
        else if (TextManager.instance.comptadorProfessor == 10)
        {
            res1 = "1. Break";
            res2 = "2. While(x==1)";
            res3 = "3. Documents Word";
            res4 = "4. Molts 'return'";

            resposta1.text = res1;
            resposta2.text = res2;
            resposta3.text = res3;
            resposta4.text = res4;

            respostaCorrecta = 1;

            // Lógica para el cambio de posición del seleccionador
            if (canNavigate && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                ChangeSelector(Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Verificar si la respuesta seleccionada es correcta
                if (indexPosicio == respostaCorrecta)
                {
                    // Permitir al jugador continuar después de seleccionar la respuesta correcta
                    PersonajeInteractuable.instance.puedeInteractuar = true;
                    TextManager.instance.allowInput = true;
                    TextManager.instance.comptadorProfessor = 11;
                }              
            }

        }
        else if (TextManager.instance.comptadorProfessor == 12)
        {
            res1 = "1. Derke";
            res2 = "2. nAts-eruni";
            res3 = "3. Boaster";
            res4 = "4. Aspas";

            resposta1.text = res1;
            resposta2.text = res2;
            resposta3.text = res3;
            resposta4.text = res4;

            respostaCorrecta = 2;

            if (canNavigate && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                ChangeSelector(Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                // Verificar si la respuesta seleccionada es correcta
                if (indexPosicio == respostaCorrecta)
                {
                    // Permitir al jugador continuar después de seleccionar la respuesta correcta
                    PersonajeInteractuable.instance.puedeInteractuar = true;
                    TextManager.instance.allowInput = true;
                    TextManager.instance.comptadorProfessor = 14;
                }
            }

        }
        else if (TextManager.instance.comptadorProfessor == 15)
        {
            res1 = "1. Snivy";
            res2 = "2. Tepig";
            res3 = "3. Emboar";
            res4 = "4. Mudkip";

            resposta1.text = res1;
            resposta2.text = res2;
            resposta3.text = res3;
            resposta4.text = res4;

            respostaCorrecta = 1;

            if (canNavigate && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                ChangeSelector(Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                // Verificar si la respuesta seleccionada es correcta
                if (indexPosicio == respostaCorrecta)
                {
                    // Permitir al jugador continuar después de seleccionar la respuesta correcta
                    PersonajeInteractuable.instance.puedeInteractuar = true;
                    TextManager.instance.allowInput = true;
                    TextManager.instance.comptadorProfessor = 17;
                }
            }

        }
        else if (TextManager.instance.comptadorProfessor == 17)
        {
            gameObject.SetActive(false);
            resposta1.gameObject.SetActive(false);
            resposta2.gameObject.SetActive(false);
            resposta3.gameObject.SetActive(false);
            resposta4.gameObject.SetActive(false);

            seleccionador.gameObject.SetActive(false);

            PlayerMovement.instance.movimentPermes = true;
        }
    }


    public void ChangeSelector(int direction)
    {
        indexPosicio += direction;

        if (indexPosicio < 1)
        {
            indexPosicio = 4;
        }
        else if (indexPosicio > 4)
        {
            indexPosicio = 1;
        }

        switch (indexPosicio)
        {
            case 1:
                seleccionador.rectTransform.position = posicio1.transform.position;
                break;
            case 2:
                seleccionador.rectTransform.position = posicio2.transform.position;
                break;
            case 3:
                seleccionador.rectTransform.position = posicio3.transform.position;
                break;
            case 4:
                seleccionador.rectTransform.position = posicio4.transform.position;
                break;
        }

        Debug.Log("Selector position: " + indexPosicio);
    }

    // Método para obtener el índice de la respuesta seleccionada
    public int ObtenerIndiceRespuestaSeleccionada()
    {
        return indexPosicio;
    }

    // Método para verificar si la respuesta seleccionada es correcta
    public bool VerificarRespuesta(int indiceRespuesta)
    {
        return indiceRespuesta == respostaCorrecta;
    }
}