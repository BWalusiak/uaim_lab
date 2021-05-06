## Dokumentacja mikrousługi danych DoctorData

--------------------------------------

##### Autorzy:

###### Krzysztof Zdulski

######  Bartosz Walusiak

-------------------------
### 1. Cel

Mikrousługa DoctorData ma za zadanie dostarczyć interfejs REST, który może służyć do obsługi prostych zapytań dotyczących danych zgromadzonych w tej usłudze. Interfejs powinien być przejrzysty oraz nie ujawniać szczegółów implementacji.

###  2. Opis danych

Mikrousługa służy do obsługi danych dotyczących doktorów. Dane przetrzymywane są w najlepszym do tego formacie XML.

Każda instancja doktora zawiera pola:
* `Id` - unikalny identyfikator doktora,
* `Name` - jest to imię i nazwisko doktora,
* `Sex` - płeć doktora,
* `Pesel` - PESEL doktora,
* `Specializations` - lista obiektów typu `Specialization` przechowujących informacje o pojedynczej specalizacji.

Każda instancja specjalizacji przechowuje:
* `Type` - typ specjalizacji,
* `CertificationDate` - data certyfikacji specjalizacji u doktora.

### 3. API 

Usługa wystawia interfejs z którego można korzystać za pomocą HTTP REST.

Usługa wystawia następujące metody na punktach końcowych:
* `/doctors` - zwraca wszyskich doktorów dostępnych w repozytorium danych.
* `/add-doctor` - za pomocą zapytania `POST` metoda ta pozwala na dodanie doktora
* `/select-specialization` - metoda zwracająca doktorów z danymi specjalizacjami
* `/doctor-id` - metoda zwracająca doktora o danym id.
* `/doctor-pesel` - metoda zwracająca doktora o danym peselu.

### 3. Testy

Do mikrousługi zostały dostarczone również testy w postaci skryptu `curl`. Aplikacja przechodzi testy i spełnia swoją funkcjonalność.
