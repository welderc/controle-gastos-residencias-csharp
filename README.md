# 🏠 Sistema de Controle de Gastos Residenciais  

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9-blue?style=for-the-badge" alt=".NET 9">
  <img src="https://img.shields.io/badge/C%23-9A4993?style=for-the-badge&logo=csharp" alt="C#">
</p>

Este projeto implementa um **Sistema de Controle de Gastos Residenciais**, permitindo o cadastro de pessoas e suas respectivas transações financeiras, como **despesas e receitas**.  

---

## ✨ Funcionalidades  

✅ **Cadastro de Pessoas**  
   - Adicionar nova pessoa (nome e idade).  
   - Visualizar todas as pessoas cadastradas.  
   - Remover pessoa (suas transações também são excluídas).  

✅ **Gestão de Transações**  
   - Registrar despesas e receitas.  
   - Listar todas as transações cadastradas.  
   - **Restrição**: Menores de idade só podem registrar despesas.  

✅ **Consulta de Totais**  
   - Exibir totais individuais (receitas, despesas e saldo por pessoa).  
   - Exibir totais gerais do sistema.  

---

## 📜 Regras de Negócio  

### 📌 Cadastro de Pessoas  
- Cada pessoa recebe um **identificador único** gerado automaticamente.  
- **Nome e idade** são obrigatórios.  
- Ao **remover uma pessoa**, todas as suas transações serão apagadas.  

### 📌 Transações Financeiras  
- Cada transação recebe um **identificador único** automaticamente.  
- **O valor da transação deve ser positivo**.  
- **Menores de 18 anos só podem registrar despesas**.  
- Tipos de transação: **DESPESA** ou **RECEITA**.  

---

## 🚀 Como Executar  

### ✅ Pré-requisitos  
- Certifique-se de ter o **.NET 9** instalado.  
- Execute o projeto com o comando abaixo:  

```sh
dotnet run
```

## Estrutura do Projeto

```
src/
├── models/
│   ├── Pessoa.cs         # Entidade Pessoa
│   ├── TamanhoTabela.cs  # Entidade TamanhoTabela
│   ├── TipoTransacao.cs  # Enum de tipos de transação
│   └── Transacao.cs      # Entidade Transação       
│
└── principal/
|    ├── CadastroPessoas.cs     # Gerenciamento de pessoas
|    ├── CadastroTransacoes.cs  # Gerenciamento de transações
|    └── ConsultaTotais.cs      # Relatórios e totalizações
└── Program.cs                # Ponto de entrada da aplicação
```

## 📌 Menu do Sistema

```
==============================
  💰 SISTEMA DE CADASTRO 💰
==============================
1️⃣  Cadastrar Pessoa
2️⃣  Cadastrar Transação
3️⃣  Exibir Pessoas
4️⃣  Exibir Transações
5️⃣  Exibir Consulta de Totais
6️⃣  Deletar Pessoa
0️⃣  Sair
```


## 🔧 Tecnologias Utilizadas

<p align="center"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="C#" width="50"> </p>


- **C#**: Linguagem de programação principal.
- **.NET 9**: Framework utilizado para a aplicação.
- **.NET Console** Execução via linha de comando.