#!/bin/sh
curl -X GET "https://localhost:5001/doctors" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/select-specialization?type=1" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/select-specialization?type=2" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/select-specialization?type=3" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/doctor-id?Id=1" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/doctor-id?Id=2" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/doctor-id?Id=3" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/doctor-id?Id=4" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/doctor-pesel?pesel=68329018173" -H  "accept: text/plain" --insecure 
curl -X GET "https://localhost:5001/doctor-pesel?pesel=86392074438" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/doctor-pesel?pesel=86392074438" -H  "accept: text/plain" --insecure
curl -X POST "https://localhost:5001/add-doctor" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"id\":51,\"name\":\"Pawel Bodenko\",\"sex\":\"Male\",\"pesel\":\"12312312312\",\"specializations\":[{\"type\":10,\"certificationDate\":\"1971-11-01T00:00:00\"},{\"type\":15,\"certificationDate\":\"2018-02-21T00:00:00\"}]}" --insecure
curl -X POST "https://localhost:5001/add-doctor" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"id\":52,\"name\":\"Agnieszka Bodenko\",\"sex\":\"Female\",\"pesel\":\"12312312312\",\"specializations\":[{\"type\":6,\"certificationDate\":\"1971-11-01T00:00:00\"},{\"type\":17,\"certificationDate\":\"2018-02-21T00:00:00\"}]}" --insecure
curl -X POST "https://localhost:5001/add-doctor" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"id\":53,\"name\":\"Rafal Kowal\",\"sex\":\"Male\",\"pesel\":\"12312312312\",\"specializations\":[{\"type\":15,\"certificationDate\":\"1971-11-01T00:00:00\"},{\"type\":15,\"certificationDate\":\"2018-02-21T00:00:00\"}]}" --insecure

