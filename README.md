# Projeto FraudeOdontologica

O projeto **FraudeOdontologica** tem como objetivo desenvolver um sistema de detecção de fraudes em convênios odontológicos, visando identificar conluios entre dentistas e pacientes. Este sistema permitirá que operadoras de planos de saúde odontológicos reduzam custos com fraudes, aumentando a eficiência na auditoria e controle de gastos.

## Novas Funcionalidades

### 1. Integração com Pagamentos (Stripe)

* **Endpoint**: `POST /api/payments` → cria um *PaymentIntent* na Stripe em modo de testes.
* **Configuração**:

  * `ExternalServices:PaymentApi`: `https://api.stripe.com/v1`
  * `Stripe__SecretKey`: variável de ambiente ou *user secret* com sua *Secret Key* (SK).

### 2. Testes Automatizados

* **Unitários**: cobertura de serviços de domínio e integração com MockHttp (`Tests/Unit`).
* **Integração**: *WebApplicationFactory* + InMemory DB (`Tests/Integration`).
* **Sistema (E2E)**: fluxos completos de criação de paciente, consulta e pagamento (`Tests/System`).
* **Execução**: rode `dotnet test` na solução para executar todos.

### 3. Clean Code & SOLID

* **SRP**: cada classe cumpre única responsabilidade.
* **OCP**: uso de interfaces (`IExternalPaymentService`, `IFraudDetectionService`).
* **LSP**: implementações respeitam contratos.
* **ISP**: interfaces granulares para serviços de Paciente, Consulta, Pagamento.
* **DIP**: controllers dependem de abstrações, não implementações.
* Métodos curtos, nomes autoexplicativos e sem *magic strings*.

### 4. Detecção de Fraude com ML.NET

* Projeto **FraudeOdonto.ML** em `/ML/FraudeOdonto.ML`:

  1. Treina modelo SDCA com dados de *Custo* e *Duração*.
  2. Gera `model.zip` em tempo de execução.
* **Endpoint**: `POST /api/fraud` → recebe `{ custo, duracao }` retorna `{ PredictedLabel, Probability, Score }`.

## Configuração

### Segredos e variáveis de ambiente

* **Oracle Connection**

  ```bash
  export ConnectionStrings__FiapOracleConnection=""
  ```
* **Stripe Secret Key**

  ```bash
  export Stripe__SecretKey=""
  ```

## Como rodar

1. **Configurar banco** (Oracle):

   ```bash
   dotnet ef database update --project fraude-odontologica
   ```
2. **Treinar modelo ML**:

   ```bash
   cd ML/FraudeOdonto.ML
   dotnet run
   ```
3. **Executar API**:

   ```bash
   dotnet run --project fraude-odontologica/fraude-odontologica.csproj
   ```
4. **Acessar Swagger**: `http://localhost:5000/index.html`

## Como testar

```bash
dotnet test
```

## Arquitetura

Monolítica em camadas:

1. **Presentation**: controladores e configuração da WebAPI.
2. **Domain**: entidades e interfaces de serviço.
3. **Infrastructure**: EF Core (Oracle/InMemory), integração Stripe e ML.
4. **ML**: console app para treinamento do modelo.

## Dependências Principais

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core (Oracle + InMemory)
* ML.NET
* xUnit, RichardSzalay.MockHttp

## Autores

* Arthur Fenili (RM552752)
* Enzo Antunes Oliveira (RM553185)
* Vinicio Raphael (RM553813)
