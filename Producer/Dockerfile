FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

RUN dotnet publish Producer.csproj -c Release -o release -v q

#WORKDIR /app
#COPY ./release ./

ENTRYPOINT ["dotnet", "Producer.dll"]