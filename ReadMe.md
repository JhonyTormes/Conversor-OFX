# Programa para conversão de OFX para XML 

Esse código foi criado par estudos, porém com uma utilidade real.
Precisei pesquisar um pouco sobre arquifos OFX (Uma linguagem padronizada de arquivos de extratos bancários.), e durante a pesquisa reparei que não se tem muitos materiais ou bibliotecas que facilitem o uso desse padrão de arquivo, portanto, fazer a conversão do arquivo ofx para um padrão com mais soluções para serialização e desserialização facilitaria muito o trabalho com as informações do arquivo. Por conta disso, me desafiei a escrever meu primeiro código utilizando windows forms criando um projeto que abre um arquivo OFX e Converte para XML.

## Atualizações futuras

Inicialmente o programa passará apenas por uma formulação visual. Farei uma interface melhor para a visualização do arquivo importado e o arquivo convertido,o programa continuará realizando apenas a função de converter o tipo do arquivo.
Futuramente poderá ser implementada desserialização do arquivo convertido para visualização dos dados em grid.

### Tecnologia utilizada.

O programa foi escrito inicialmente no Visual Studio 2017 na linguagem C#, mas foi recompilado posteriormente utilizando o Visual Studio 2022.