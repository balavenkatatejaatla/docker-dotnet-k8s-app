Run locally 

dotnet nuget locals all --clear
dotnet restore
dotnet build
dotnet run
dotnet D:\Analysis\new\StudentApp\bin\Debug\net8.0\StudentApp.dll

Run Docker Locally

docker build -t studentapp -f Dockerfile .
docker run -d -p 5000:8080 --name studentapp_container studentapp

APis Access:
GET : 
curl --location 'http://localhost:5000/api/students'

POST
curl --location 'http://localhost:5000/api/students' \
--header 'Content-Type: application/json' \
--data '
    {
        "student_name": "teja",
        "student_age": 21,
        "student_addr": "123 Main St",
        "student_percent": 88.5,
        "student_qual": "M.Sc",
        "student_year_passed": 2024
    }'

PUT
curl --location --request PUT 'http://localhost:5000/api/students/2' \
--header 'Content-Type: application/json' \
--data '
    {
        "student_id": 2,
        "student_name": "teja2",
        "student_age": 21,
        "student_addr": "123 Main St",
        "student_percent": 88.5,
        "student_qual": "M.Sc",
        "student_year_passed": 2024
    }'

DELETE
curl --location --request DELETE 'http://localhost:5000/api/students/1'










