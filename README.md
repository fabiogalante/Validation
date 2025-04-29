## **Visão Geral do Projeto**
Este projeto implementa um **motor de validação flexível e extensível**. Ele permite definir “templates” de validação que agrupam diferentes validadores para finalidades variadas (como por exemplo "Cadastro" ou "Pagamento"), facilitando o reuso e a organização das regras de negócio.
## **Principais Componentes do Sistema**
### 1. **IValidator (Interface)**
- **O que faz:** Define o contrato para qualquer validador do sistema. Ou seja, todo validador precisa implementar um método para validar dados e devolver se está válido ou não.

### 2. **ValidationResult (Classe)**
- **O que faz:** Representa o resultado de uma validação. Contém:
    - Se está válido (`IsValid`)
    - Lista de erros encontrados durante a validação (`Errors`)

### 3. **ValidationTemplate (Classe)**
- **O que faz:** Define quais validadores serão executados para cada cenário/template. Exemplo: no template "Cadastro", quais validadores são necessários?

### 4. **ValidatorFactory (Classe)**
- **O que faz:** É uma fábrica que instancia os validadores baseando-se no nome deles. Permite criar validadores de maneira desacoplada e flexível.

### 5. **ValidationEngine (Classe principal)**
- **O que faz:** Orquestra tudo:
    - Recebe dados para validar
    - Consulta o template para saber quais validadores usar
    - Usa a `ValidatorFactory` para criar os validadores
    - Executa todos eles e junta o resultado final

## **Validadores Implementados (Exemplos)**
- **AgeValidator:** Verifica se a pessoa é maior de idade.
- **AntiFraudValidator:** Simula validação antifraude, incluindo chamada fictícia para API externa.
- **DocumentValidator:** Valida documentos (também simulando comunicação externa).

## **Como Funciona na Prática**
1. **Configuração do Motor de Validação**
    - O `ValidationEngine` é criado e recebe o registro dos templates (“Cadastro”, “Pagamento”), indicando quais validadores devem ser chamados em cada template.

2. **Execução**
    - Você informa:
        - O template que quer usar (ex: "Cadastro")
        - Os dados a serem validados (ex: nome, idade, documento)

    - O sistema executa todos os validadores previstos no template, agregando os resultados.
    - Se algum validador reprovar, ele informa todos os erros encontrados.

## **Resumo do Fluxo**
1. **Registrar templates:** Dizer quais validadores usar em cada cenário (“Cadastro” ou “Pagamento”).
2. **Enviar dados para validação:** Informar os dados de uma pessoa e qual template usar.
3. **Receber resultado:** Saber se passou em todos validadores ou ver a lista de erros.

## **Principais Vantagens**
- **Extensível:** Fácil adicionar novos validadores.
- **Configurável:** Templates controlam quais regras aplicam em cada situação.
- **Desacoplado:** Lógica dos validadores separada do motor de orquestração.
