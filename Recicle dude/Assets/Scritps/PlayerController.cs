using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontal, vertical, divisorDeForca;
    private Animator anim;
    private GameObject gameC;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        gameC = GameObject.Find("GameController");
    }

    public void Animador()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (vertical > 0 /*&& gameC.GetComponent<GameController>().vidaJogador > 0*/)
        {
            anim.SetInteger("estado", 1);
        }

        else if (vertical <= 0 /*&& gameC.GetComponent<GameController>().vidaJogador > 0*/)
        {
            anim.SetInteger("estado", 0);
        }
    }

    public void AdicionarForca()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * 2;
        vertical = Input.GetAxisRaw("Vertical");

        if (vertical > 0)
        {
            transform.Translate(new Vector3(0, 0, vertical / divisorDeForca));
        }

        if (horizontal > 0)
        {
            transform.Rotate(0, horizontal, 0);
        }

        if(horizontal < 0)
        {
            transform.Rotate(0, horizontal, 0);
        }
    }

    private void Update()
    {
        AdicionarForca();
        Animador();

        //if (gameC.GetComponent<GameController>().vidaJogador <= 0)
        //{
        //    anim.SetInteger("estado", 3)
        //}
    }
}
