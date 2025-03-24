using System;

namespace controle_gastos_residencias
{
    /*
        Classe principal que contém o ponto de entrada do sistema de controle de gastos.
        Gerencia a interação do usuário com o sistema por meio de um menu interativo.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instancia os módulos principais do sistema
            CadastroPessoas cadastroPessoas = new CadastroPessoas();
            CadastroTransacoes cadastroTransacoes = new CadastroTransacoes();
            ConsultaTotais consultaTotais = new ConsultaTotais(cadastroPessoas, cadastroTransacoes);

            // Loop principal para interação com o usuário
            while (true)
            {
                // Exibe o menu principal
                Console.WriteLine("\n==============================");
                Console.WriteLine("  💰 SISTEMA DE CADASTRO 💰");
                Console.WriteLine("==============================");
                Console.WriteLine("1️⃣  Cadastrar Pessoa");
                Console.WriteLine("2️⃣  Cadastrar Transação");
                Console.WriteLine("3️⃣  Exibir Pessoas");
                Console.WriteLine("4️⃣  Exibir Transações");
                Console.WriteLine("5️⃣  Exibir Consulta de Totais");
                Console.WriteLine("6️⃣  Deletar Pessoa");
                Console.WriteLine("0️⃣  Sair");
                Console.Write("\n👉 Escolha uma opção: ");
                
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        cadastroPessoas.cadastrar(); // Cadastro de pessoa
                        break;
                    case 2:
                        cadastroTransacoes.cadastrar(cadastroPessoas); // Cadastro de transação
                        break; 
                    case 3:
                        cadastroPessoas.exibir(); // Exibição de pessoas cadastradas
                        break;
                    case 4:
                        cadastroTransacoes.exibir(); // Exibição de transações registradas
                        break;
                    case 5:
                        consultaTotais.exbirTotais(); // Exibição do relatório financeiro
                        break;
                    case 6:
                        Console.Write("Digite o ID da pessoa a ser deletada: "); // Exclusão de pessoa e suas transações
                        int idDeletar = int.Parse(Console.ReadLine());

                        cadastroPessoas.deletar(idDeletar, cadastroTransacoes);
                        break;
                    case 0:
                        Console.WriteLine("\n🚪 Saindo do sistema... Até mais! 👋");
                        return;
                    default:
                        Console.WriteLine("\n ❌ Opção inválida! Tente novamente.");
                        continue;
                }
            }
        
        }


    }
}