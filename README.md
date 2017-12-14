# CISSP201711
CISSP tanfolyam 2017 november-december.

## Segédeszközök
- [MarkDown](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
- [GitHub](https://github.com/gplesz/CISSP201711)

## Témakörök
- Computing Systems
- Databases
- Software Development

## Computing Systems
### Hardware
### Processor
- Moore törvénye (Gordon Moore)
  - 1965: ezt követően tíz évig _a tranzisztorok sűrűsége_ meg fog duplázódni az integrált áramkörökön
  - 1975: újraértékelt, és további 10 évre kiterjeszti
  - David House (Intel): 18 havonta a _teljesítmény_ duplázódik (a mennyiség mellett a sebességgel is számol)

  Példa: Lotus 1-2-3 (DOS, 640k)/Excel párharca (Windows)

### Execution Type
- Multitasking
Több feladat egyidejű végrehajtására képes a rendszer. A legtöbb rendszer nem képes erre, az operációs rendszer szimulálja a CPU idejének a felosztásával.

- Multiprocessing
Párhuzamos végrehajtásra képes rendszerek. Egynél több processzorral egyszerre több feladat végrehajtása zajlik.
  - SMP (Simmetric Multiprocessing): egy számítógép több processzort tartalmaz, ugyanaz az OS kezeli őket, általában nem csak az OS közös, hanem az adathozzáférés és a memóriahasználat is. Több processzor, általában 2-16 db.
  - MPP (Massive Parallel processing): több száz processzor vagy több ezer processzor, minden processzorhoz saját adathozzáférés és operációs rendszer. Például particionált adatok (facebook ország szerinti adatai, google keresés)

- Multiprogramming
A multitaskinghoz hasonlóan több feladat egyidejű végrehajtására képes programozást jelent.

```



                                                                                +--------------+
                                                                                | Adatbázis    |
        +----------------+                                                      |--------------|
        | Böngésző       |                        +-------------------+    +--->|              |
        |----------------|                        | Alkalmazásszerver |    ^    |              |
        |                |                        |-------------------|    |    |              |
        |                +----------------------->|Kérés végrehajtása |+---+    +--------------+
        |                |                        |Vár az adatbázisra | (miközben az adatbéázisra vár, közben a többi 
        |                |                        |Kérés végrehajtás  |  feladatot végrehajtja)
        |                |                        |       folytatása  |
        +----------------+                        +-------------------+
```
   - inkább a régi nagy mainframe-ek sajátja, a multitask pedig a PC-kre jellemző
   - a multitaskot az OS kezeli, a multiprogramminghoz speciálisan megírt programra van szükség

- Multithreading (többszálú végrehajtás)
  Lehetővé teszi az operációs rendszer szolgáltatásával, hogy egy alkalmazáson belül párhuzamos feladatvégrehajtás történjen úgy, hogy különleges programozásra nincs szükség. Azért hatékony, mert a szálak közti váltások sokkal gyorsabbak (50 utasítás) mint a processzek közti váltások (1000 utasítás)

- Process (folyamat)
  Egy alkalmazás és a futtatásához szükséges környezet.
- Thread  (szál)
  A folyamaton (alkalmazáson) belül végrehajtási szál, saját call stack-kel. Az OS biztosítja. 

### Processing Types
A magas biztonságú rendszerek úgy felügyelik az információfeldolgozás folyamatát, hogy különböző biztonsági szintekhez rendelik őket.
- besorolás nélküli
- érzékeny
- bizalmas
- titkos
- szigorúan titkos

#### Single state
Egyszerre csak egyféle biztonsági szintet kezel a rendszer. A biztonsági adminisztrátor kezeli, nem a számítógép, vagy az OS.

#### Multi State
Egyszerre több biztonsági hozzáférést képes nyújtani. Ehhez tartalmaz védelmi mechanizmust, hogy a biztonsági szintek átlépését kivédje. Ez a mechanizmus nagyon költséges, és az ilyen rendszerek nagyon ritkák. Egyes drága MPP rendszerekhez ritkán van olyan indok, ami értelmessé teszi ezt a fajta kialakítást.

### Protection rings
Az operációs rendszerek tervezésénél védelmi körökbe szervezik a feladatokat.

```
+----------------------------------------------------------------+
|   User-level programs and applications                         |
|----------------------------------------------------------------|
|                                                                |
|                                                                |
|        +----------------------------------------------+        |
|        |  Drivers, protocols                          |        |
|        |----------------------------------------------|        |
|        |                                              |        |
|        |                                              |        |
|        |        +--------------------------+          |        |
|        |        |  Other OS component      |          |        |
|        |        |--------------------------|          |        |
|        |        |   +------------------+   |          |        |
|        |        |   | OS kernel/memory |   |          |        |
|        |        |   |------------------|   |          |        |
|        |        |   |                  |   |          |        |
|        |        |   |                  |   |          |        |
|        |        |   |                  |   |          |        |
|        |        |   +------------------+   |          |        |
|        |        |                          |          |        |
|        |        +--------------------------+          |        |
|        |                                              |        |
|        |                                              |        |
|        +----------------------------------------------+        |
|                                                                |
+----------------------------------------------------------------+
```
- ring 0 (legbelsőbb kör)
- ring 1
- ring 2
- ring 3 (felhasználói rendszerek)

### Process states

```
                   Process needs another time slice
 New process    <--------------------------------------+^                   Stopped
      +         +                                       |                       ^
      |         |                                       |        When process   |
      |         |                                       |        finished or    |
      |         v      If CPU is available              +        terminated     +
      +-----> Ready +------------------------------> Running  +----------------->
                                                     ^   +
                                        +------------+   |
                                        |                |
                                        |                | block for I/O,
                                        |                | resources
                                        |unblocked       |
                                        |                |
                                        |                |
                                        |                |
                                        +                |
                                                         |
                                     Waiting <-----------+
```


- Ready
  A folyamat kész arra, hogy elkezdje a végrehajtást. Ha lesz szabad processzor, akkor ezt a folyamatot végre is hajthatja. A hozzárendelt erőforrások ki vannak neki osztva.
- Waiting
  A folyamatunk külső erőforrásra vár. A futása addig, amíg az erőforráshozzáférés meg nem történik, blokkolva van.
- Running
  A folyamat CPU végrehajtás közben van. Addig tart, amíg (a) nem végez, (b) le nem jár az időszelete (c) egy erőforráshozzáférés miatt blokkolt állapotba kerül.
- Supervisory
  Amikor magasabb jogok szükségesek (egy körrel beljebb kellene kerülni), driver telepítés, stb.
- Stopped
  Amikor a folyamat végzett, vagy meg kell szakítani (hiba, nem elérhető erőforrás, stb.) A hozzárendelt erőforrások elvonhatók, újraoszthatók.

### Memory
- ROM: Read-Only Memory
- PROM: Programmable Read-Only Memory
- EPROM: Erasable Programmable Read-Only Memory
- EEPROM: Electronically Erasable Programmable Read-Only Memory
- Flash: blokkonként törölhető EEPROM
- RAM: Random Access Memory
  - dinamic: kapacitásokból áll, a CPU-nak időnként frissítenie kell.
  - static: flip-flop áramkörök, nem kell a CPU-nak frissíteni. Amíg áram alatt van nem felejt. Gyorsabb és dágább.
Cache RAM: Level1: a processzoron, Level2: static RAM

### Registers
Speciális memóriák, szinkron sebességgel dolgoznak, mint a processzor végrehajtási egysége (ALU: Arithmetic-logical unit)
- Register addressing: amikor a porcesszor a regisztert címzi, hivatkozza (register 1)
- Inmediate addressing: közvetlen műveletvégzés a regiszter segítségével (add 2 to register 1)
- Direct addressing: a registerben a memóriahely címe van, amivel dolgozni kell, ahol az adat van. (a cím egy lapon van a paranccsal)
- Indirect addressing: a registerben lévő memóriahelyen újabb cím vár minket: az a cím, ahol az adat van, amivel dolgozni kell. (a cím egy lapon van a paranccsal)
- Base + Offset addressing: ha nem azonos lapon van az adat, akkor a lapcím + a lapon belüli cím jelenti az adat címét, amivel dolgozunk.

### Primary, Secondary Storaga
- Primary memory: "valódi memória", amit a processzor a regiszter műveletekkel eléri (gyors és drága)
- Secondary storage: először be kell tölteni a primary memóriába, hogy használni tudjuk. (lassú és olcsó)

### Virtual Memory, Virtual Storage
Olyan másodlagos memóriák, amiket az operációs rendszer használ, segítségével elsődlegesnek látszik. Hátránya a sebessége.

### I/O Devices
- Monitor
- Printer
- Keyboard/Mouse
- Modems
- I/O structures
  - Memory-Mapped I/O
  - IRQ
  - DMA
- Firmware
  - BIOS
  - Device Firmware





