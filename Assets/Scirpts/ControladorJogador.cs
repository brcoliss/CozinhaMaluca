using System.Security.Cryptography;
using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public float taxaMovimentacao;
    public Geral JuizdoJogo;
    private object posicaoObj;

    // Update is called once per frame
    void Update()
    {

        float altX, altY;

        // Para cima e para baixo
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 478)
            altY = 60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 23)
            altY = -60 * Time.deltaTime * taxaMovimentacao;
        else
            altY = 0;

        // Para os lados
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 23)
            altX = -60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 938)
            altX = 60 * Time.deltaTime * taxaMovimentacao;
        else
            altX = 0;

        // Modificar posi��o:

        Vector3 novaPos = new Vector3(altX, altY, 0);
        transform.position += novaPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Voador")
        { 
            //Marcando um ponto no plcar
            JuizdoJogo.MarcarPonto();

            //Volta o objeto para a posi��o 
            collision.GetComponent<Boladev>().posicaoObj.x =
                collision.GetComponent<Boladev>().posInicialX;


            //Atualizar a posi��o vertical do objeto 
            float posicaoY = Random.value * 470;
            collision.GetComponent<Boladev>().posicaoObj.y = posicaoY;

            // Trocar a imagem do objeto a ser coletado
            collision.GetComponent<Boladev>().MudarImagem();
        }   
              
    }

}
