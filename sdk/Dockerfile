FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN mkdir -p /usr/src
WORKDIR /usr/src

COPY Finbourne.Drive.Sdk.sln /usr/src/
COPY Finbourne.Drive.Sdk/Finbourne.Drive.Sdk.csproj /usr/src/Finbourne.Drive.Sdk/
RUN dotnet restore Finbourne.Drive.Sdk

ENV FBN_DRIVE_API_URL ${FBN_DRIVE_API_URL}

# ENTRYPOINT [ "/bin/bash" ]
ENTRYPOINT dotnet build --configuration Release --verbosity normal Finbourne.Drive.Sdk