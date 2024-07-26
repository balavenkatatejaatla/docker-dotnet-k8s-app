Run locally 

dotnet nuget locals all --clear
dotnet restore
dotnet build
dotnet run
dotnet D:\Analysis\new\StudentApp\bin\Debug\net8.0\StudentApp.dll

Run Docker Locally

docker build -t studentapp -f Dockerfile .
docker run -d -p 5000:8080 --name studentapp_container studentapp
