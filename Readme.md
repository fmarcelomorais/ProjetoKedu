\# 📌 \*\*Título do Projeto\*\*

Projeto Kedu



---



\## 📖 \*\*Descrição\*\*

Projeto teste - Controle de planos de pagamento.



---



\## 🚀 \*\*Tecnologias Utilizadas\*\*

\- .NET 8

\- ASP.NET Core Web API

\- Dapper

\- PostgreSQL 



---



\## ⚙️ \*\*Como Executar o Projeto\*\*



\### 1. \*\*Clonar o repositório\*\*



```bash

git clone https://github.com/fmarcelomorais/ProjetoKedu.git

cd ProjetoKedu

```

\### 2 . Execulta os comandos

dotnet restore

dotnet run --project src/ProjetoKedu.Api/ProjetoKedu.Api.csproj



\### 3. Acessa o Swagger

https://localhost:7294/swagger/index.html



\## Exemplos de chamadas



\### api/PlanoPagamento

&nbsp;- Request

&nbsp;   ```json

&nbsp;       {

&nbsp;       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

&nbsp;       "responsavel": {

&nbsp;           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

&nbsp;           "nome": "string"

&nbsp;       },

&nbsp;       "centroDeCusto": {

&nbsp;           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

&nbsp;           "codigo": 0,

&nbsp;           "tipo": "string"

&nbsp;       },

&nbsp;       "cobrancas": \[

&nbsp;           {

&nbsp;           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

&nbsp;           "numero": 0,

&nbsp;           "valor": 0,

&nbsp;           "dataVencimento": "2025-12-01T14:09:09.534Z",

&nbsp;           "metodoPagamento": "BOLETO",

&nbsp;           "statusCobranca": "EMITIDA",

&nbsp;           "codigoPagamento": "string"

&nbsp;           }

&nbsp;       ],

&nbsp;       "valorTotalPlano": 0

&nbsp;       }

&nbsp;   ```



&nbsp;   ### api/cobranca/id/pagamento

&nbsp;- Request

&nbsp;    id por queryParans

&nbsp;   ```json

&nbsp;       {

&nbsp;           "valor": 0,

&nbsp;           "dataPagemento": "2025-12-01T14:12:41.539Z"

&nbsp;       }

&nbsp;   ```



