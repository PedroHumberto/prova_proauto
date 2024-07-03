# Registro de Placas

- Versão .Net 8.0


Antes de executar o projeto, execute o arquvi solução **RegistroDePlacas.sln**, garantindo que todas as bibliotecas e arquivos estarão integros. 



*Trabalho feito para a prova, vaga de desenvolvedor .net*


## API
Para rodar a API deve selecionar a pasta raiz RegistroDePlaca.API e no console digitar ``dotnet run``

## Web
Para rodar o projeto web primeiro deve selecionar a pasta raiz RegistroDePlaca.Web e no console digitar ``dotnet run``

### Endpoints:

##### HTTP (``http://localhost:5270/api/usuario/cadastrar``)

**Request Body:**
*Schema:*
```json
{
  "nome": "string",
  "cpf": "string",
  "endereco": {
    "rua": "string",
    "numero": "string",
    "complemento": "string",
    "bairro": "string",
    "cep": "string",
    "cidade": "string",
    "estado": "string"
  },
  "telefone": "string",
  "placaDoVeiculo": "string"
}
```
**Response Body**
*Schema:*
```json
{
  "success": true || false,
  "message": "string",
  "data": {
    "nome": "string",
    "cpf": {
      "numero": "string"
    },
    "endereco": {
      "rua": "string",
      "numero": "string",
      "complemento": "string",
      "bairro": "string",
      "cep": "string",
      "cidade": "string",
      "estado": "string"
    },
    "telefone": "string",
    "placaDoVeiculo": "string"
  }
}
```

---

##### HTTP (``http://localhost:5270/api/usuario/update_endereco``)

**Request Body:**
*Schema*
```json
{
  "cpf": "string",
  "endereco": {
    "rua": "string",
    "numero": "string",
    "complemento": "string",
    "bairro": "string",
    "cep": "string",
    "cidade": "string",
    "estado": "string"
  }
}
```

**Response Body**
*Schema:*
```json
{
  "success": true || false,
  "message": "string",
  "data": {
    "endereco": {
      "rua": "string",
      "numero": "string",
      "complemento": "string",
      "bairro": "string",
      "cep": "string",
      "cidade": "string",
      "estado": "string"
    }
  }
}
```
