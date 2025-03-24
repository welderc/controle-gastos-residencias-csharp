using System;


/*
    Classe responsável por definir os tamanhos das colunas utilizadas na exibição de tabelas.
    Fornece configurações para alinhar corretamente os dados de pessoas e transações.
*/
class TamanhoTabela
{
    // Configuração das colunas para exibição de pessoas
    public static int IdNome => 5; // Largura da coluna de ID da pessoa
    public static int Nome => 40; // Largura da coluna de Nome
    public static int Idade => 5; // Largura da coluna de Idade

    // Configuração das colunas para exibição de transações
    public static int IdTrasacao => 5;          // Largura da coluna de ID da transação
    public static int Descricao => 28;          // Largura da coluna de Descrição
    public static int Valor => 22;              // Largura da coluna de Valor
    public static int Tipo => 12;               // Largura da coluna de Tipo da transação
    public static int IdPessoa => 10;           // Largura da coluna de ID da pessoa associada

    // Tamanho da linha separadora
    public static int LinhaHorizontal => 80;    

}