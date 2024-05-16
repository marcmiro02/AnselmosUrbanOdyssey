using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class TextManager : MonoBehaviour
{
    public static TextManager instance; // Propiedad estática para acceder a la instancia de TextManager
    public BocadilloUI bocadilloUI;
    public GameObject quiosqueroGameObject;
    public GameObject trinxatGameObject;
    public GameObject professorGameObject;
    public GameObject blackVoidObject;
    public GameObject taxistaObject;
    public GameObject timGameObject;
    public GameObject ciclistaGameObject;
    public GameObject barqueroGameObject;
    private QuiosqueroTexto quiosqueroTexto;
    private CapitaTrinxatTexto capitaTrinxatTexto;
    private ProfessorTexto professorTexto;
    private BlackVoidTexto blackVoidTexto;
    private TaxistaTexto taxistaTexto;
    private TimTexto timTexto;
    private CiclistaTexto ciclistaTexto;
    private BarqueroTexto barqueroTexto;

    public GameObject caixaFort;

    public GameObject puntClasse;
    public GameObject puntPiscina;

    public int comptadorQuiosquero = 0;
    public int comptadorTrinxat = 0;
    public int comptadorProfessor = 0;
    public int comptadorBlackVoid = 0;
    public int comptadorTaxista = 0;
    public int comptadorTim = 0;
    public int comptadorCiclista = 0;
    public int comptadorBarquero = 0;


    public bool aigua = false;
    public bool acabarTextTrinxat = false;
    public bool component1 = false;
    public int comptadorComponents = 0;

    public bool allowInput = true;

    public GameObject paperet;

    void Start()
    {
        // Configurar la instancia del TextManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Ya hay una instancia de TextManager en la escena.");
            Destroy(this.gameObject); // Destruir el objeto actual para evitar duplicados
            return;
        }

        // Obtener el componente QuiosqueroTexto del GameObject
        quiosqueroTexto = quiosqueroGameObject.GetComponent<QuiosqueroTexto>();
        capitaTrinxatTexto = trinxatGameObject.GetComponent<CapitaTrinxatTexto>();
        professorTexto = professorGameObject.GetComponent<ProfessorTexto>();
        blackVoidTexto = blackVoidObject.GetComponent<BlackVoidTexto>();
        taxistaTexto = taxistaObject.GetComponent<TaxistaTexto>();
        timTexto = timGameObject.GetComponent<TimTexto>();
        ciclistaTexto = ciclistaGameObject.GetComponent<CiclistaTexto>();
        barqueroTexto = barqueroGameObject.GetComponent<BarqueroTexto>();

        taxistaObject.SetActive(false);
        ciclistaGameObject.SetActive(false);

        puntClasse.SetActive(false);
        puntPiscina.SetActive(false);

        paperet.SetActive(false);  
    }

    public string ObtenerSiguienteTextoQuiosquero()
    {
        GameObject[] valles1 = GameObject.FindGameObjectsWithTag("Valles-Inicials4");
        GameObject[] valles2 = GameObject.FindGameObjectsWithTag("Valles-Inicials1");

        if (quiosqueroTexto != null && quiosqueroTexto.textosQuiosquero.Length > 0)
        {
            //HO PUC FER AMB UN BUCLE FOR??

            if (comptadorQuiosquero == 1)
            {
                return quiosqueroTexto.textosQuiosquero[1];
            }
            else if (comptadorQuiosquero == 2 && aigua)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[2];
            }
            else if (comptadorQuiosquero == 3)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[3];
            }
            else if (comptadorQuiosquero == 4)
            {
                foreach (GameObject objeto in valles1)
                {
                    Destroy(objeto);
                }
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[4];
            }
            else if (comptadorQuiosquero == 5)
            {
                return quiosqueroTexto.textosQuiosquero[5];
            }
            else if (comptadorQuiosquero == 6 && component1)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[6];
            }
            else if (comptadorQuiosquero == 7)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[7];
            }
            else if (comptadorQuiosquero == 8)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[8];
            }
            else if (comptadorQuiosquero == 9)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[9];
            }
            else if (comptadorQuiosquero == 10)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[10];
            }
            else if (comptadorQuiosquero == 11)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[11];
            }
            else if (comptadorQuiosquero == 12)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[12];
            }
            else if (comptadorQuiosquero == 13)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[13];
            }
            else if (comptadorQuiosquero == 14)
            {
                comptadorQuiosquero++;
                comptadorTim++;
                return quiosqueroTexto.textosQuiosquero[14];
            }
            else if (comptadorQuiosquero == 15)
            {
                foreach (GameObject objeto in valles2)
                {
                    Destroy(objeto);
                }
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[15];
            }
            else if (comptadorQuiosquero == 16)
            {
                return quiosqueroTexto.textosQuiosquero[16];
            }
            else if (comptadorQuiosquero == 17)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[17];
            }
            else if (comptadorQuiosquero == 18)
            {
                return quiosqueroTexto.textosQuiosquero[18];
            }
            else if (comptadorQuiosquero == 19)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[19];
            }
            else if (comptadorQuiosquero == 20)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[20];
            }
            else if (comptadorQuiosquero == 21)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[21];
            }
            else if (comptadorQuiosquero == 22)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[22];
            }
            else if (comptadorQuiosquero == 23)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[23];
            }
            else if (comptadorQuiosquero == 24)
            {
                return quiosqueroTexto.textosQuiosquero[24];
            }
            else if (comptadorQuiosquero == 25)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[25];
            }
            else if (comptadorQuiosquero == 26)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[26];
            }
            else if (comptadorQuiosquero == 27)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[27];
            }
            else if (comptadorQuiosquero == 28)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[28];
            }
            else if (comptadorQuiosquero == 29)
            {
                return quiosqueroTexto.textosQuiosquero[29];
            }
            else if (comptadorQuiosquero == 30)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[30];
            }
            else if (comptadorQuiosquero == 31)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[31];
            }
            else if (comptadorQuiosquero == 32)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[32];
            }
            else if (comptadorQuiosquero == 33)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[33];
            }
            else if (comptadorQuiosquero == 34)
            {
                return quiosqueroTexto.textosQuiosquero[34];
            }
            else if (comptadorQuiosquero == 35)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[35];
            }
            else if (comptadorQuiosquero == 36)
            {
                return quiosqueroTexto.textosQuiosquero[36];
            }
            else if (comptadorQuiosquero == 37)
            {
                bocadilloUI.nombreText.gameObject.SetActive(true);
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[37];
            }
            else if (comptadorQuiosquero == 38)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[38];
            }
            else if (comptadorQuiosquero == 39)
            {
                comptadorQuiosquero++;
                comptadorTrinxat = 28;
                return quiosqueroTexto.textosQuiosquero[39];
            }
            else if (comptadorQuiosquero == 40)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[40];
            }
            else if (comptadorQuiosquero == 41)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[41];
            }
            else if (comptadorQuiosquero == 42)
            {
                bocadilloUI.gameObject.SetActive(true);
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[42];
            }
            else if (comptadorQuiosquero == 43)
            {
                comptadorQuiosquero = 50;
                comptadorCiclista++;
                paperet.SetActive(true);
                bocadilloUI.gameObject.SetActive(true);
                return quiosqueroTexto.textosQuiosquero[43];
            }
            else if (comptadorQuiosquero == 44)
            {               
                return quiosqueroTexto.textosQuiosquero[44];
            }
            else if (comptadorQuiosquero == 45)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[45];
            }
            else if (comptadorQuiosquero == 46)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[46];
            }
            else if (comptadorQuiosquero == 47)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[47];
            }
            else if (comptadorQuiosquero == 48)
            {
                comptadorQuiosquero++;
                return quiosqueroTexto.textosQuiosquero[48];
            }
            else if (comptadorQuiosquero == 49)
            {
                return quiosqueroTexto.textosQuiosquero[49];
            }
            else if (comptadorQuiosquero == 50)
            {
                bocadilloUI.nombreText.gameObject.SetActive(false);
                taxistaObject.SetActive(true);
                return quiosqueroTexto.textosQuiosquero[50];
            }

            comptadorQuiosquero++;
            return quiosqueroTexto.textosQuiosquero[0];
        }
        else
        {
            Debug.LogWarning("No se encontraron textos del Quiosquero.");
            return string.Empty;
        }
    }

    public string ObtenerSiguienteTextoTrinxat()
    {
        GameObject[] valles3 = GameObject.FindGameObjectsWithTag("Valles-Inicials2");
        GameObject[] valles4 = GameObject.FindGameObjectsWithTag("Valles-Inicials3");

        if (capitaTrinxatTexto != null && capitaTrinxatTexto.textosTrinxat.Length > 0)
        {
            if (comptadorTrinxat == 0)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[0];
            }
            else if (comptadorTrinxat == 1)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[1];
            }
            else if (comptadorTrinxat == 2)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[2];
            }
            else if (comptadorTrinxat == 3)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[3];
            }
            else if (comptadorTrinxat == 4)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[4];
            }
            else if (comptadorTrinxat == 5)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[5];
            }
            else if (comptadorTrinxat == 6)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[6];
            }
            else if (comptadorTrinxat == 7)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[7];
            }
            else if (comptadorTrinxat == 8)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[8];
            }
            else if (comptadorTrinxat == 9)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[9];
            }
            else if (comptadorTrinxat == 10)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[10];
            }
            else if (comptadorTrinxat == 11)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[11];
            }
            else if (comptadorTrinxat == 12)
            {
                comptadorQuiosquero = 17;
                acabarTextTrinxat = true;
                foreach (GameObject objeto in valles3)
                {
                    Destroy(objeto);
                }
                return capitaTrinxatTexto.textosTrinxat[12];
            }
            else if (comptadorTrinxat == 13)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[13];
            }
            else if (comptadorTrinxat == 14)
            {               
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[14];
            }
            else if (comptadorTrinxat == 15)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[15];
            }
            else if (comptadorTrinxat == 16)
            {
                ciclistaGameObject.gameObject.SetActive(true);
                foreach (GameObject objeto in valles4)
                {
                    Destroy(objeto);
                }
                comptadorQuiosquero = 19;
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[16];
            }
            else if (comptadorTrinxat == 17)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[17];
            }
            else if (comptadorTrinxat == 18)
            {
                return capitaTrinxatTexto.textosTrinxat[18];
            }
            else if (comptadorTrinxat == 19)
            {
                return capitaTrinxatTexto.textosTrinxat[19];
            }
            else if (comptadorTrinxat == 20)
            {
                return capitaTrinxatTexto.textosTrinxat[20];
            }
            else if (comptadorTrinxat == 21)
            {
                comptadorTrinxat++;
                comptadorTim++;
                return capitaTrinxatTexto.textosTrinxat[21];
            }
            else if (comptadorTrinxat == 22)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[22];
            }
            else if (comptadorTrinxat == 23)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[23];
            }
            else if (comptadorTrinxat == 24)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[24];
            }
            else if (comptadorTrinxat == 25)
            {
                bocadilloUI.gameObject.SetActive(false);
                bocadilloUI.nombreText.gameObject.SetActive(false);
                bocadilloUI.textoText.gameObject.SetActive(false);
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[25];
            }
            else if (comptadorTrinxat == 26)
            {              
                comptadorQuiosquero = 37;
                return capitaTrinxatTexto.textosTrinxat[26];
            }
            else if (comptadorTrinxat == 27)
            {
                bocadilloUI.gameObject.SetActive(true);
                bocadilloUI.nombreText.gameObject.SetActive(true);
                bocadilloUI.textoText.gameObject.SetActive(true);
                comptadorQuiosquero = 37;
                return capitaTrinxatTexto.textosTrinxat[27];
            }
            else if (comptadorTrinxat == 28)
            {
                return capitaTrinxatTexto.textosTrinxat[28];
            }
            else if (comptadorTrinxat == 29)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[29];
            }
            else if (comptadorTrinxat == 30)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[30];
            }
            else if (comptadorTrinxat == 31)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[31];
            }
            else if (comptadorTrinxat == 32)
            {
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[32];
            }
            else if (comptadorTrinxat == 33)
            {
                bocadilloUI.gameObject.SetActive(false);
                bocadilloUI.nombreText.gameObject.SetActive(false);
                bocadilloUI.textoText.gameObject.SetActive(false);
                comptadorTrinxat++;
                return capitaTrinxatTexto.textosTrinxat[33];
            }
            else if (comptadorTrinxat == 34)
            {
                return capitaTrinxatTexto.textosTrinxat[34];
            }
            else if (comptadorTrinxat == 35)
            {               
                return capitaTrinxatTexto.textosTrinxat[35];
            }
            else if (comptadorTrinxat == 36)
            {
                return capitaTrinxatTexto.textosTrinxat[36];
            }
        }
        return capitaTrinxatTexto.textosTrinxat[comptadorTrinxat];
    }

    public string ObtenerSiguienteTextoProfessor()
    {
        if (professorTexto != null && professorTexto.textosProfessor.Length > 0 && allowInput)
        {

            if (comptadorProfessor == 0)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[0];
            }
            else if (comptadorProfessor == 1)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[1];
            }
            else if (comptadorProfessor == 2)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[2];
            }
            else if (comptadorProfessor == 3)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[3];
            }
            else if (comptadorProfessor == 4)
            {
                PlayerMovement.instance.movimentPermes = false;
                BocadilloPreguntes.instance.gameObject.SetActive(true);
                BocadilloPreguntes.instance.resposta1.gameObject.SetActive(true);
                BocadilloPreguntes.instance.resposta2.gameObject.SetActive(true);
                BocadilloPreguntes.instance.resposta3.gameObject.SetActive(true);
                BocadilloPreguntes.instance.resposta4.gameObject.SetActive(true);

                BocadilloPreguntes.instance.seleccionador.gameObject.SetActive(true);

                return professorTexto.textosProfessor[4];
            }
            else if (comptadorProfessor == 5)
            {
                comptadorProfessor = 4;
                return professorTexto.textosProfessor[5];
            }
            else if (comptadorProfessor == 6)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[6];
            }
            else if (comptadorProfessor == 7)
            {
                return professorTexto.textosProfessor[7];
            }
            else if (comptadorProfessor == 8)
            {
                comptadorProfessor = 7;
                return professorTexto.textosProfessor[8];
            }
            else if (comptadorProfessor == 9)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[9];
            }
            else if (comptadorProfessor == 10)
            {
                return professorTexto.textosProfessor[10];
            }
            else if (comptadorProfessor == 11)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[11];
            }
            else if (comptadorProfessor == 12)
            {
                PersonajeInteractuable.instance.puedeInteractuar = false;
                return professorTexto.textosProfessor[12];
            }
            else if (comptadorProfessor == 13)
            {
                comptadorProfessor = 12;
                return professorTexto.textosProfessor[13];
            }
            else if (comptadorProfessor == 14)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[14];
            }
            else if (comptadorProfessor == 15)
            {
                PersonajeInteractuable.instance.puedeInteractuar = false;
                return professorTexto.textosProfessor[15];
            }
            else if (comptadorProfessor == 16)
            {
                comptadorProfessor = 15;
                return professorTexto.textosProfessor[16];
            }
            else if (comptadorProfessor == 17)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[17];
            }
            else if (comptadorProfessor == 18)
            {
                comptadorProfessor++;
                return professorTexto.textosProfessor[18];
            }
            else if (comptadorProfessor == 19)
            {
                puntClasse.SetActive(true);
                return professorTexto.textosProfessor[19];
            }
        }
        return professorTexto.textosProfessor[comptadorProfessor];
    }

    public string ObtenerSiguienteTextoBlackVoid()
    {
        if (comptadorBlackVoid == 0)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[0];
        }
        else if (comptadorBlackVoid == 1)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[1];
        }
        else if (comptadorBlackVoid == 2)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[2];
        }
        else if (comptadorBlackVoid == 3)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[3];
        }
        else if (comptadorBlackVoid == 4)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[4];
        }
        else if (comptadorBlackVoid == 5)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[5];
        }
        else if (comptadorBlackVoid == 6)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[6];
        }
        else if (comptadorBlackVoid == 7)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[7];
        }
        else if (comptadorBlackVoid == 8)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[8];
        }
        else if (comptadorBlackVoid == 9)
        {
            bocadilloUI.gameObject.SetActive(false);
            bocadilloUI.nombreText.gameObject.SetActive(false);
            bocadilloUI.textoText.gameObject.SetActive(false);
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[9];
        }
        else if (comptadorBlackVoid == 10)
        {
            return blackVoidTexto.textosBlackVoid[10];
        }
        else if (comptadorBlackVoid == 11)
        {
            bocadilloUI.nombreText.gameObject.SetActive(true);
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[11];
        }
        else if (comptadorBlackVoid == 12)
        {
            comptadorBlackVoid++;
            return blackVoidTexto.textosBlackVoid[12];
        }
        else if (comptadorBlackVoid == 13)
        {
            puntPiscina.SetActive(true);
            return blackVoidTexto.textosBlackVoid[13];
        }

        return blackVoidTexto.textosBlackVoid[comptadorBlackVoid];
    }
    public string ObtenerSiguienteTextoTaxista()
    {
        if(comptadorTaxista == 0)
        {
            comptadorTaxista++;
            return taxistaTexto.textosTaxista[0];
        }
        else if (comptadorTaxista == 1)
        {
            comptadorTaxista++;
            return taxistaTexto.textosTaxista[1];
        }
        else if (comptadorTaxista == 2)
        {
            comptadorTaxista++;
            return taxistaTexto.textosTaxista[2];
        }
        else if (comptadorTaxista == 3)
        {
            comptadorTaxista++;
            return taxistaTexto.textosTaxista[3];
        }
        else if (comptadorTaxista == 4)
        {
            comptadorTaxista++;
            return taxistaTexto.textosTaxista[4];
        }
        else if (comptadorTaxista == 5)
        {
            return taxistaTexto.textosTaxista[5];
        }

        return taxistaTexto.textosTaxista[comptadorTaxista];
    }

    public string ObtenerSiguienteTextoTim()
    {
        if (comptadorTim == 0)
        {
            return timTexto.textosTim[0];
        }
        else if (comptadorTim == 1)
        {
            return timTexto.textosTim[1];
        }
        else if (comptadorTim == 2)
        {           
            return timTexto.textosTim[2];
        }
        return timTexto.textosTim[comptadorTim];
    }

    public string ObtenerSiguienteTextoCiclista()
    {
        if (comptadorCiclista == 0)
        {
            return ciclistaTexto.textosCiclista[0];
        }
        else if (comptadorCiclista == 1)
        {
            comptadorCiclista++;
            return ciclistaTexto.textosCiclista[1];
        }
        else if (comptadorCiclista == 2)
        {
            comptadorCiclista++;
            return ciclistaTexto.textosCiclista[2];
        }
        else if (comptadorCiclista == 3)
        {
            comptadorCiclista++;
            return ciclistaTexto.textosCiclista[3];
        }
        else if (comptadorCiclista == 4)
        {
            return ciclistaTexto.textosCiclista[4];
        }
        return ciclistaTexto.textosCiclista[comptadorCiclista]; 

    }

    public string ObtenerSiguienteTextoBarquero()
    {
        if (comptadorBarquero == 0)
        {
            comptadorBarquero++;
            return barqueroTexto.textosBarquero[0];
        }
        else if(comptadorBarquero == 1)
        {
            comptadorBarquero--;
            return barqueroTexto.textosBarquero[1];
        }
        return barqueroTexto.textosBarquero[comptadorBarquero]; 
    }

        
}
