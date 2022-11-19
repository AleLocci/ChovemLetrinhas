using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palavra : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh Palavra;
    string[] Dicionario = { "Amar", "Paz", "Fala", "La" };
    string manipula = "";
    string vaiMudar;
    string corMuda;
    int index;
    RaycastHit hit;

    void Start()
    {

        Palavra.text = Dicionario[escolhePalavra(Dicionario)];
        manipula = Palavra.text;
        vaiMudar = pegarCaracter('a', manipula);
        corMuda = corString(vaiMudar, Color.red);
        manipula = manipula.Replace(vaiMudar, corMuda);
        Palavra.text = manipula;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 position = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
            Debug.Log(worldPos + " " + position);

            Ray ray = Camera.main.ScreenPointToRay(worldPos);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit.collider != null)
            {
                Debug.Log("CLICKED " + hit.collider.name);
            }

        }

    }

    private int escolhePalavra(string[] tam)
    {

        int range = tam.Length - 1;
        int pal = Random.Range(0, range);
        return pal;

    }

    private string corString(string text, Color color)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">" + text + "</color>";
    }

    private string pegarCaracter(char ocorrencia, string palavra)
    {

        int index = palavra.IndexOf(ocorrencia);
        return palavra[index].ToString();

    }

}
