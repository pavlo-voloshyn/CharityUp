#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Payment/API/PaymentService.API.csproj", "src/Services/Payment/API/"]
COPY ["src/Services/Payment/Application/PaymentService.Application.csproj", "src/Services/Payment/Application/"]
COPY ["src/Services/Payment/DataAccess/PaymentService.DataAccess.csproj", "src/Services/Payment/DataAccess/"]
COPY ["src/Services/Payment/Domain/PaymentService.Domain.csproj", "src/Services/Payment/Domain/"]
RUN dotnet restore "src/Services/Payment/API/PaymentService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Payment/API"
RUN dotnet build "PaymentService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentService.API.dll"]