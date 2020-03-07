# Docker Azure Api

## test

https://dockerazuretest2.azurewebsites.net/weatherforecast

http://localhost:8080/weatherforecast

https://hub.docker.com/repository/docker/mjdocker31/test2api

## status check
- docker -v
- docker ps
- docker image list
- docker container list -all
- docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" metalsprices_test1

## build
- docker build -t test2 . 
- docker run -d -p 8080:80 --name myapp test2

## cleanup

- docker rmi test2
- docker stop 9d
- docker container rm 9d

## hub
- docker login -u "user" -p "password" docker.io
- docker push mjdocker31/test2api

## net core
- dotnet new webapp -o aspnetcoreapp
- dotnet run --MetalsPrices.Api

## useful links:

### Azure
https://medium.com/@pugillum/asp-net-core-2-web-api-docker-and-azure-f84e28aa6267

### Localhost
https://docs.docker.com/engine/examples/dotnetcore/

### Other

https://softchris.github.io/pages/dotnet-dockerize.html#why

https://docs.microsoft.com/pl-pl/visualstudio/containers/tutorial-multicontainer?view=vs-2019

https://forums.docker.com/t/docker-push-error-requested-access-to-the-resource-is-denied/64468/6
