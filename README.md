<div align="center">
	<img width="300px" src="https://user-images.githubusercontent.com/49994083/232264227-18af486f-de7c-4ab8-bf44-33f7db886f7e.png">
	<br>
	<h1>atento</h1>
	<p>Monitor de cotações da B3</p>
</div>

## Sobre

**atento** (**a**lerta de **te**ndências e **n**egociações para **t**raders **o**nline) é um sistema desenvolvido para monitorar a cotação de ativos da B3 e enviar um email de alerta caso o valor do ativo esteja acima de um certo nível ou abaixo de outro.

## Instalação

Primeiro, clone e entre no repositório:

```bash
git clone https://github.com/diksown/atento
cd atento
```

Depois, mude o `appsettings.json` para as suas configurações pessoais.

```yaml
{
  "toEmail": "to@example.com",
  "smtpConfig": {
    "primaryDomain": "smtp.gmail.com",
    "primaryPort": 587,
    "senderEmail": "sender@example.com",
    "senderPassword": "password"
  }
}
```

## Uso

```bash
dotnet run -- <ativo> <preco_para_venda> <preco_para_compra>
```

Onde:
- `ativo` é o código do ativo a ser monitorado
- `preco_para_venda` é o preço de referência para venda
- `preco_para_compra` é o preço de referência para compra

### Exemplo:

```bash
dotnet run -- PETR4 22.67 22.59
```
