using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlTablas : MonoBehaviour
{
    [Header("-----Prefab-----")]
    [SerializeField] GameObject ObjetoTexto;
    [Space(20)]
    [Header("-----Contenedores-----")]
    [SerializeField] RectTransform CtokensToken;
    [SerializeField] RectTransform CtokensLexemas;
    [Space(10)]
    [SerializeField] RectTransform CtablaLexemas;
    [SerializeField] RectTransform CtablaToken;
    [SerializeField] RectTransform CtablaTipo;
    [SerializeField] RectTransform CtablaNumLinea;
    [SerializeField] RectTransform CtablaValor;
    [SerializeField] RectTransform CtablaDesplasamiento;
    [SerializeField] RectTransform CtablaValorDesplasamiento;
    [Space(10)]
    [SerializeField] RectTransform CmensajesTipo;
    [SerializeField] RectTransform CmensajesDescripcion;
    [SerializeField] RectTransform CmensajesLinea;
    [Space(20)]
    [Header("-----ListasPalabrasReservadas-----")]
    [SerializeField] List<string> Lexemas;
    [SerializeField] List<string> Token;
    [SerializeField] List<string> Tipo;

    [Space(20)]
    [Header("-----ListasTablas-----")]
    [SerializeField] List<TextMeshProUGUI> LisTokenLexemas;
    [SerializeField] List<TextMeshProUGUI> LisTokenToken;
    [SerializeField] List<int> LisTokenLinea;
    [Space(10)]
    [SerializeField] List<TextMeshProUGUI> LisTablaLexemas;
    [SerializeField] List<TextMeshProUGUI> LisTablaToken;
    [SerializeField] List<TextMeshProUGUI> LisTablaTipo;
    [SerializeField] List<TextMeshProUGUI> LisTablaNumLinea;
    [SerializeField] List<TextMeshProUGUI> LisTablaValor;
    [SerializeField] List<TextMeshProUGUI> LisTablaDesplasamiento;
    [SerializeField] List<TextMeshProUGUI> LisTablaValorDesplasamiento;
    [Space(10)]
    [SerializeField] List<TextMeshProUGUI> LisMensajesTipo;
    [SerializeField] List<TextMeshProUGUI> LisMensajesDescripcion;
    [SerializeField] List<TextMeshProUGUI> LisMensajesLinea;

    private void Start()
    {
        RellenarBace();
    }
    void RellenarBace()
    {
        LisTokenToken = new List<TextMeshProUGUI>();
        LisTokenLexemas = new List<TextMeshProUGUI>();
        LisTokenLinea = new List<int>();

        LisTablaLexemas = new List<TextMeshProUGUI>();
        LisTablaToken = new List<TextMeshProUGUI>();
        LisTablaTipo = new List<TextMeshProUGUI>();
        LisTablaNumLinea = new List<TextMeshProUGUI>();
        LisTablaValor = new List<TextMeshProUGUI>();
        LisTablaDesplasamiento = new List<TextMeshProUGUI>();
        LisTablaValorDesplasamiento = new List<TextMeshProUGUI>();

        LisMensajesTipo = new List<TextMeshProUGUI>();
        LisMensajesDescripcion = new List<TextMeshProUGUI>();
        LisMensajesLinea = new List<TextMeshProUGUI>();
        for (int i = 0; i < Lexemas.Count; i++)
        {
            CrearTexto(Lexemas[i], CtablaLexemas, LisTablaLexemas);
            CrearTexto(Token[i], CtablaToken, LisTablaToken);
            CrearTexto(Tipo[i], CtablaTipo, LisTablaTipo);
            CrearTexto("", CtablaNumLinea, LisTablaNumLinea);
            CrearTexto("", CtablaValor, LisTablaValor);
            CrearTexto("", CtablaDesplasamiento, LisTablaDesplasamiento);
            CrearTexto("", CtablaValorDesplasamiento, LisTablaValorDesplasamiento);
        }
    }
    public void ComprobarIdentificador(string lexema, string token, string tipo, int linea)
    {
        bool paso = true;
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (lexema == LisTablaLexemas[i].text)
            {
                paso = false;
                AgregarToken(lexema, LisTablaToken[i].text, linea);
                break;
            }
        }
        if (paso == true)
        {
            AgregarToken(lexema, token, linea);
            AgregarIdentificador(lexema, token, tipo, "" + linea, "", "");
        }
    }
    void CrearTexto(string Informacion, RectTransform Posicion, List<TextMeshProUGUI> Lista)
    {
        GameObject Creado = Instantiate(ObjetoTexto);
        Creado.transform.SetParent(Posicion);
        Lista.Add(Creado.GetComponent<TextMeshProUGUI>());
        Lista[Lista.Count - 1].text = Informacion;
    }
    public void LimpiarTodo()
    {
        int num = LisTokenLexemas.Count;
        for (int i = 0; i < num; i++)
        {
            Destroy(LisTokenLexemas[i].gameObject);
            Destroy(LisTokenToken[i].gameObject);
        }
        num = LisTablaLexemas.Count;
        for (int i = 0; i < num; i++)
        {
            Destroy(LisTablaLexemas[i].gameObject);
            Destroy(LisTablaToken[i].gameObject);
            Destroy(LisTablaTipo[i].gameObject);
            Destroy(LisTablaNumLinea[i].gameObject);
            Destroy(LisTablaValor[i].gameObject);
            Destroy(LisTablaDesplasamiento[i].gameObject);
            Destroy(LisTablaValorDesplasamiento[i].gameObject);
        }
        num = LisMensajesTipo.Count;
        for (int i = 0; i < num; i++)
        {
            Destroy(LisMensajesTipo[i].gameObject);
            Destroy(LisMensajesDescripcion[i].gameObject);
            Destroy(LisMensajesLinea[i].gameObject);
        }
        RellenarBace();
    }
    public void AgregarToken(string lexema, string token, int Lin)
    {
        CrearTexto(lexema, CtokensLexemas, LisTokenLexemas);
        CrearTexto(token, CtokensToken, LisTokenToken);
        LisTokenLinea.Add(Lin);
    }
    public void AgregarMensaje(string tipo, string descri, string linea)
    {
        CrearTexto(tipo, CmensajesTipo, LisMensajesTipo);
        CrearTexto(descri, CmensajesDescripcion, LisMensajesDescripcion);
        CrearTexto(linea, CmensajesLinea, LisMensajesLinea);
    }
    void AgregarIdentificador(string lexema, string token, string tipo, string linea, string valor, string despla)
    {
        CrearTexto(lexema, CtablaLexemas, LisTablaLexemas);
        CrearTexto(token, CtablaToken, LisTablaToken);
        CrearTexto(tipo, CtablaTipo, LisTablaTipo);
        CrearTexto(linea, CtablaNumLinea, LisTablaNumLinea);
        CrearTexto(valor, CtablaValor, LisTablaValor);
        CrearTexto(despla, CtablaDesplasamiento, LisTablaDesplasamiento);
        CrearTexto("", CtablaValorDesplasamiento, LisTablaValorDesplasamiento);
    }
    public List<string> RegresarListaTokens()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTokenToken.Count; i++)
        {
            t.Add(LisTokenToken[i].text);
        }
        return t;
    }
    public List<int> RegresarListaLineas()
    {
        List<int> t = new List<int>();
        for (int i = 0; i < LisTokenLinea.Count; i++)
        {
            t.Add(LisTokenLinea[i]);
        }
        return t;
    }
    public List<string> RegresarListaLexemas()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTokenLexemas.Count; i++)
        {
            t.Add(LisTokenLexemas[i].text);
        }
        return t;
    }
    public bool VariableDeclarada(string Iden)
    {
        bool SeEncontro = false;
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (LisTablaLexemas[i].text == Iden)
            {
                if (LisTablaTipo[i].text != "")
                {
                    SeEncontro = true;
                }
                break;
            }
        }
        return SeEncontro;
    }
    public void AgregarTipo(string Iden, string T)
    {
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (LisTablaLexemas[i].text == Iden)
            {
                LisTablaTipo[i].text = T;
                break;
            }
        }
    }
    public void AgregarValor(string Iden, string T)
    {
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (LisTablaLexemas[i].text == Iden)
            {
                LisTablaValor[i].text = T;
                break;
            }
        }
    }
    public void agregarDes(int pos, int despla)
    {
        LisTablaDesplasamiento[pos].text = "" + despla;
    }
    public void agregarValorDes(int pos, int despla)
    {
        LisTablaValorDesplasamiento[pos].text = "" + despla;
    }
    public List<string> RegresarListaTokens2()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTablaToken.Count; i++)
        {
            t.Add(LisTablaToken[i].text);
        }
        return t;
    }
    public List<string> RegresarListaLexemas2()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            t.Add(LisTablaLexemas[i].text);
        }
        return t;
    }
    public List<string> RegresarListaTipo()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTablaTipo.Count; i++)
        {
            t.Add(LisTablaTipo[i].text);
        }
        return t;
    }
    public List<string> RegresarListaValor()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTablaValor.Count; i++)
        {
            t.Add(LisTablaValor[i].text);
        }
        return t;
    }
    public List<string> RegresarListaDesplasamiento()
    {
        List<string> t = new List<string>();
        for (int i = 0; i < LisTablaDesplasamiento.Count; i++)
        {
            t.Add(LisTablaDesplasamiento[i].text);
        }
        return t;
    }
    public string regresarDespla(int p)
    {        
        return LisTablaValorDesplasamiento[p].text;
    }
    public void CambiarToken(string Iden, string T)
    {
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (LisTablaLexemas[i].text == Iden)
            {
                LisTablaToken[i].text = T;
                break;
            }
        }
    }
    public string RegresarTipo(string Iden)
    {
        string T="";
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (LisTablaLexemas[i].text == Iden)
            {
                T = LisTablaTipo[i].text;
                break;
            }
        }
        return T;
    }
    public string RegresarValor(string Iden)
    {
        string T = "";
        for (int i = 0; i < LisTablaLexemas.Count; i++)
        {
            if (LisTablaLexemas[i].text == Iden)
            {
                T = LisTablaValor[i].text;
                break;
            }
        }
        return T;
    }
}
