System zarządzania magazynem rowerów
Dokumentacja ma na celu zapewnienie informacji o projekcie, jego funkcjonalnościach oraz technologiach. Stanowi punkt odniesienia dla wszystkich zainteresowanych stron, ułatwiając pracę nad aplikacją. Opis: System zarządzania magazynem rowerów jest przeznaczony dla firm, które chcą kontrolować swój magazyn rowerów. 
Technologie:
 Backend: C# .NET 
Framework: ASP.NET MVC
Baza danych: MS SQL Server 
Frontend: HTML, CSS, Bootstrap, JavaScript 
Projekt ten zapewni wsparcie dla zarządzania magazynem rowerów. Dodatkowe funkcje, które okażą się niezbędne do prawidłowego działania aplikacji, będą dodawane podczas jej tworzenia. 

Instrukcja pierwszego uruchomienia: 
- Instalacja Azure Data Studio
Dodanie bazy danych za pomocą polecenia: 
RESTORE DATABASE [CycleSyncHubDb]
FROM DISK = N'ścieżka\Backup.bak'
WITH FILE = 1,
MOVE N' CycleSyncHubDb ' TO N'Ścieżka\ CycleSyncHubDb.mdf',
MOVE N' CycleSyncHubDb _Log' TO N'ścieżka\CycleSyncHubDb _log.ldf',
NOUNLOAD, STATS = 5; 

Jeśli jest potrzeba wykonanie polecenia „Update-Database”
Użytkownicy: 
Owner@gmail.com hasło – Owner123!
Opis Projektu
Użytkownicy z odpowiednimi rolami mogą dodawać, edytować i usuwać rowery w magazynie. Do tego został użyty wzorzec projektowy mediator. 
Zarządzanie rowerami: Zalogowani użytkownicy mają możliwość przeglądania rowerów oraz wchodzenia w szczegóły. Nie zalogowani użytkownicy mogą tylko przeglądać dostępne rowery. Właściciel (Owner) ma możliwość dodawania nowych rowerów, edytowania oraz ich usuwania.
Autorzy: Jan Cieśliński, Bartosz Łapo

