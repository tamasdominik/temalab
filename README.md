# temalab

CSAPAT: 
- Csík Tamás (FMXR64) csktomi@gmail.com
- Tamás Dominik (WZB0XZ) tamasdominikmate@gmail.com
- Zanati Nóra (XOOBG5) zanati.nora@gmail.com
- Dávid Ferenc (OT59Q7) ferkodavid5@gmail.com
        
Témalabor első lépések
# Az webapplikáció neve: „FitneC#”


Specifikáció:  
Alapötlet: A témalabor keretén belül egy webalkalmazást fogunk elkészíteni. A program lehetővé teszi, hogy felhasználók regisztrálhassanak, illetve beléphessenek a felületre, ott profilt hozzanak létre, majd összeállíthatják egyedi edzéstervüket. A gyakorlatok és feladatok előre adottak lesznek és ezekből tetszés szerint választhat a felhasználó. Minden gyakorlathoz fog tartozni nehézségi szint, alapértelmezett kivitelezési mennyiség (pl. fekve-nyomásból 4-szer 12 ismétlés) és elégetett kalória mennyisége. A felhasználó létrehozhat saját edzéseket és ezeket tetszés szerint elnevezheti, összeállíthatja a gyakorlatokból. Lesznek előre megadott edzéstervek, ezek közül is lehet választani. Az edzéstervekhez tartozik egy „elvégezve” gomb, amivel jelezhetjük a rendszernek, hogy az adott edzés kész van és hozzáadódik a statisztikákhoz. Elérhetők lesznek mérföldkövek és kitüntetések, melyeket a kimagasló teljesítményével szerezhet meg a felhasználó (pl.: 5000 elégetett kalória). Külön statisztika menüpontban lesznek elérhetőek az eddig elvégzett gyakorlatok mennyiségei (pl.: lefutott órák száma:56). További menüpont lesz a ranglista, melyben elégetett kalória szerint lesznek rangsorolva a felhasználók. 

Felépítés: A webalkalmazás 6 fő menüpontot foglal magába:
•	Regisztráció/bejelentkezés: Az első lépés a regisztráció, meg kell adnunk az e-mail címünket, felhasználónevünket és a jelszót, ha már regisztráltunk korábban, akkor e-mail cím és a jelszó megadásával beléphetünk a felületre. 
•	profil: bejelentkezés után ez az alapértelmezett oldal, amelyről navigálhatunk a további menüpontokra. Itt a felhasználónak lehetősége van jelszó-módosításra, alap paraméterek megadására (testsúly, magasság stb.).
•	edzések: Ebben a menüpontban lesznek elérhetőek az alapértelmezett edzések, valamint a felhasználó bővítheti egyediekkel is. Minden edzést a mellette található „elvégezve” gombbal tekinthetjük befejezettnek, ezzel együtt hozzáadódik a statisztikákhoz az elvégzett gyakorlatok mennyisége. Lehetőség van törölni, illetve módosítani az egyedi edzésterveket.
•	statisztika: Az adott felhasználónak külön gyakorlatokra szétbontva megtekinthető az eddigi teljesítménye.
•	ranglista: Itt a felhasználók sorrendbe vannak állítva az elégetett kalória mennyisége alapján.
•	mérföldkövek: Ebben a menüpontban láthatjuk az összes elérhető mérföldkövet, teljesítés esetén a „megszerezve” felirat jelenik meg, a még nem teljesített mérföldkövek mellett, pedig a haladás állapota.

Technológia: A webalkalmazáshoz használt adatbázis MSSQL lesz, az adatelérési réteget entity framework-kel implementáljuk. Az app SPA-ként lesz megvalósítva és Angular keretrendszert fogunk hozzá használni. Verziókezelés Githubon fog történni.
