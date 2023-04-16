<h1>atento 🧐</h1>

> Monitor de cotações da B3

<h3 align="center">
	<a href=".">Sobre</a> · 
	<a href=".">Instalação</a> · 
	<a href=".">Uso</a> · 
	<a href=".">Referências</a>
</h3>

<h2>O que é `atento`?</h2>

atento (**a**lerta de **te**ndências e **n**egociações para **t**raders **o**nline) é um sistema desenvolvido para monitorar a cotação de ativos da B3 e enviar um email de alerta caso o valor do ativo esteja acima de um certo nível ou abaixo de outro.

<h2>Instalação</h2>

Primeiro, clone e entre no repositório:

```bash
git clone https://github.com/diksown/atento
cd atento
```

Depois, mude o `appsettings.json` para as suas configurações pessoais.

<h2>Uso</h2>

```bash
dotnet run -- <ativo> <preco_para_venda> <preco_para_compra>
```

Onde:
`ativo` é o código do ativo a ser monitorado
`preco_para_venda` é o preço de referência para venda
`preco_para_compra` é o preço de referência para compra
