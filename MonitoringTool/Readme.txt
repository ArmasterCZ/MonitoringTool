# MonitoringTool
je program pro správce sítě, monitorující určité spektrum problémů.
pracuje na principu smyčky kontrol prováděné pomocí Timer1 (metoda timer1_Tick) zapínané tlačítkem Start vpravo dole.

Popis jednotlivých monitorovacích oken:
	(departmentCheck)
	 - kontroluje dostupnost IP adres (ping). Ty jsou uloženy v xml souborech (každý pro jednu IP adresu) a je možné je souborově přidávat.
	 
	(lockedOutAccount)
	 - skrz AD hledá zamknuté doménové účty. Využívá powershellový skript. (Search-ADAccount –LockedOut)

	(lockedOutEmails)
	 - připojí se souborově na poštovní server (icewarp) s přihlašovacími údaji uloženými pod App.Config. 
	   Stáhne datový soubor indukující zamknutí. Zkontroluje bit na pozici a vrátí seznam zaklých emailů.
	   (Vykazuje zhruba 30% chybovost pro neodmazání dříve zamknutých uživatelů)

	(expiredPasswords)
	 - skrz AD hledá exspirované Doménové účty. Využívá powershellový sript. 
	   (get-ADuser ... -Properties pwdLastSet,PasswordNeverExpires,..)

	(checkEmailsToSend)
	 - připojí se souborově na poštovní server (icewarp) s přihlašovacími údaji uloženými pod App.Config.
	   A zkontroluje počet emailů čekajících na odeslání. 

	(lockedOutOldList)
	 - získá seznam zamknutých účtů z logu na DC. Využívá powershellový skript.
	   (Get-WinEvent -ComputerName $PDCEmulator.HostName -FilterHashtable @{LogName='Security';Id=4740})
	   
	 
Správcovské funkce:
	(lockedOutAccount)
	 - odemknutí účtu.
	 
	(lockedOutEmails)
	 - smazání uzamknutí.

	(expiredPasswords)
	 - nastavení nového hesla.
	 
	(lockedOutOldList)
	 - 5 typů exportů dat.