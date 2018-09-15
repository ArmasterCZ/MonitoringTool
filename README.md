# MonitoringTool

`Jméno:` MonitoringTool, 
`Datum:` 2017.07.*??*, 
`Projekt:` Visual studio *2015-2017*, 
`Framework:` 4.6, 
`Jazyk programu:` Čeština, 
`Jazyk komentářů:` Změť chybějících popisků, českých popisů funkcí a anglických popisů tříd, 
`Popis:` Nástroj na monitorování problémů ve firemní doméně.

`Plný popis:` 
Rychle vytvořený nástroj pro monitorování požadovaných problémů v doméně, později dodělána  rozkliknutelná řešení. 
Primární idea byla vytvořit jednoduchou nástavbu pro fungující PowerShellové skripty s přehledným grafickým rozhraním a jednoduchou rozšiřitelností. [Náhled rozhraní.](https://github.com/ArmasterCZ/MonitoringTool/blob/master/MonitoringTool/printScreen.JPG)

Skládá z:
- monitorování dostupných IP adress
- uzamknutých účtů v AD
- účtů s vypršelým heslem v AD
- uzamknutých účtů na poštovním serveru (IceWarp)
- naposledy uzamknutých AD účtů s informací o čase a počítači ze kterého byli uzamknuty
- monitorování počtu emailu čekajících na odeslání

Rozkliknutelná řešení:
- odemknutí AD účtu
- odemknutí IceWarptího účtu
- nastavení nového hesla AD účtu
- zkopírování názvů označených počítačů
