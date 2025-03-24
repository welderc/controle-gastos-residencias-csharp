using System;

/*
    Classe que representa uma pessoa no sistema de controle de gastos.
    Cada pessoa possui um identificador único, nome e idade.
*/

class Pessoa 
{
    private int identificador;
    private string nome;
    private int idade;

    public Pessoa(string nome, int idade, int identificador)
    {
        this.identificador = identificador;
        this.nome = nome;
        this.idade = idade;
    }

    public int Identificador
    {
        get{return identificador;}
        set{identificador=value;}
    }

    public string Nome
    {
        get{return nome;}
        set{nome=value;}
    }

    public int Idade
    {
        get{return idade;}
        set{idade=value;}
    }


}