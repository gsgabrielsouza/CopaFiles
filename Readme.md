# Copa Filmes

Copa dos melhores filmes selecionados pelos usuários

## Primeiros Passos

#### Pré-requisitos

- [Docker]( https://docs.docker.com/install/ )
- [Aspnet Core 3.0](https://dotnet.microsoft.com/download/dotnet-core)
- [NodeJs](https://nodejs.org/en/download/)
- 

##### Yarn e React

```
npm install -g yarn
npm install -g create-react-app 
```

##### Docker

É necessário possuir o Docker instalado para execução da aplicação.

```
docker build -t moviecup -f Dockerfile .
docker run -d -p 8080:5000 moviecup
```

##### Executar através do CLI

```
dotnet restore
dotnet run --project src\MovieCup.API\MovieCup.API.csproj
```



