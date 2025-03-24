using System;

/*
    Classe que representa uma transação financeira no sistema.
    Cada transação está associada a uma pessoa e pode ser do tipo DESPESA ou RECEITA.
    Para menores de idade (idade < 18), apenas transações do tipo DESPESA são permitidas.
*/

class Transacao
{
    private int identificador;
    private String descricao;
    private double valor;
    private TipoTransacao tipo;
    private int idPessoa;

    public Transacao (int identificador, string descricao, double valor, TipoTransacao tipo, int idPessoa)
    {
        this.identificador = identificador;
        this.descricao = descricao;
        this.valor = valor;
        this.tipo = tipo;
        this.idPessoa = idPessoa;
    }

    public int Identificador
    {
        get{return identificador;}
        set{identificador=value;}
    }

    public string Descricao
    {
        get{return descricao;}
        set{descricao=value;}
    }

    public double Valor
    {
        get{return valor;}
        set{valor=value;}
    }

    public TipoTransacao Tipo
    {
        get{return tipo;}
        set{tipo=value;}
    }

    public int IdPessoa
    {
        get{return idPessoa;}
        set{idPessoa=value;}
    }

}