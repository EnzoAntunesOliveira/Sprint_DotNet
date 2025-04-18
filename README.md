# Projeto FraudeOdontologica

O projeto **FraudeOdontologica** tem como objetivo desenvolver um sistema de detecção de fraudes em convênios odontológicos, visando identificar conluios entre dentistas e pacientes. Este sistema permitirá que operadoras de planos de saúde odontológicos reduzam custos com fraudes, aumentando a eficiência na auditoria e controle de gastos.

## Objetivo do Projeto

O principal objetivo deste projeto é:

- Detectar e prevenir fraudes em convênios odontológicos, proporcionando um meio eficiente para operadoras de saúde auditarem e controlarem seus gastos.

## Escopo

O escopo do projeto inclui:

- Desenvolvimento de uma API para gerenciar informações de pacientes, dentistas, consultas e tratamentos.
- Implementação de funcionalidades de detecção de fraudes utilizando algoritmos de machine learning.
- Criação de uma interface para visualização de dados e relatórios sobre fraudes detectadas.
- Integração com sistemas existentes das operadoras de planos de saúde.

### Funcionalidades Principais

- Cadastro de Pacientes e Dentistas.
- Registro e gerenciamento de Consultas e Tratamentos.
- Detecção de anomalias em dados de consultas e tratamentos.
- Relatórios sobre fraudes identificadas e estatísticas relacionadas.

### Funcionalidades Futuras

- **Registro de Consultas**: Permitir o cadastro e gerenciamento de consultas realizadas entre pacientes e dentistas.
- **Pagamentos e Sinistros**: Gerenciamento de pagamentos feitos pelas operadoras e registro de sinistros.

## Requisitos Funcionais

1. **Cadastro de Pacientes**: Permitir o registro de informações de pacientes, incluindo nome, CPF, e dados de contato.
2. **Cadastro de Dentistas**: Permitir o registro de informações de dentistas, incluindo nome, CRO e especialidade.
3. **Gerenciamento de Consultas**: Permitir o registro de consultas associadas a pacientes e dentistas.
4. **Registro de Tratamentos**: Permitir a associação de tratamentos a consultas realizadas.
5. **Detecção de Fraudes**: Implementar algoritmos para identificar possíveis fraudes em consultas e tratamentos.
6. **Relatórios**: Gerar relatórios com informações sobre fraudes detectadas.

## Requisitos Não Funcionais

1. **Segurança**: A aplicação deve proteger os dados sensíveis dos pacientes e dentistas.
2. **Desempenho**: A detecção de fraudes deve ser realizada em tempo real ou em tempo aceitável.
3. **Escalabilidade**: O sistema deve ser capaz de lidar com um número crescente de usuários e dados.
4. **Usabilidade**: A interface do usuário deve ser intuitiva e fácil de usar.

## Desenho da Arquitetura

A arquitetura adotada é **Monolítica**, onde todas as funcionalidades estão integradas em um único projeto. A escolha por uma arquitetura monolítica se deu pela simplicidade e rapidez na implementação, dado que a aplicação não exige uma grande escalabilidade desde o início. A estrutura do projeto segue o modelo tradicional de camadas, divididas entre apresentação, aplicação, domínio e infraestrutura.

### Camadas da Aplicação

1. **Apresentação**:
    - Contém a camada da API, onde os controladores recebem as requisições HTTP e retornam as respostas apropriadas. É responsável pela comunicação com o cliente.

2. **Aplicação**:
    - Esta camada contém serviços e casos de uso da aplicação, implementando a lógica de negócios e orquestrando a comunicação entre a camada de apresentação e a camada de domínio.

3. **Domínio**:
    - Contém as entidades e as regras de negócio. É o núcleo do sistema, onde as entidades como Paciente, Dentista, Consulta e Tratamento são definidas.

4. **Infraestrutura**:
    - Esta camada é responsável pelo acesso a dados, incluindo o contexto do banco de dados e a configuração da conexão. Ela também pode incluir a integração com outras APIs e serviços externos.

## Design Patterns

- **Builder**: Utilizado para a construção de objetos complexos, como consultas e tratamentos.
- **Singleton**: Em breve, um gerenciador de configurações será implementado utilizando o padrão Singleton, garantindo que a configuração do sistema seja única e compartilhada por toda a aplicação.
  
## Como rodar 

- Rodar diretamente pela IDE (Rider) ou com o comando "dotnet run" (Visual Studio) para automaticamente abrir o Swagger e testar as APIs no `http://localhost:5000/index.html`
- Por enquanto, os endpoints adicionados foram de CRUD para Paciente e Dentista.

## Autores

- Arthur Fenili RM552752
- Enzo Antunes Oliveira RM553185
- Vinicio Raphael RM553813
