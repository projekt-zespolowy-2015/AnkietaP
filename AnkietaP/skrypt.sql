Begin Transaction;
Drop TABLE mieszkaniec;
Drop table wynik_bool;
Drop table wynik_lista;
drop table opcje;
drop table pytanie;
drop table kategoria_pytania;
drop table powiat_gmina;
drop table miejscowosc;
drop table ulica;
drop table adres;
drop table ankieta;



CREATE TABLE  ankieta  (
	 id_ankieta 	INTEGER,
	 opis 	VARCHAR(100),
	 data_od 	DATETIME,
	 dota_do 	DATETIME,
	PRIMARY KEY(id_ankieta)
);

CREATE TABLE  adres  (
	 id_adres 	INTEGER,
	 miejscowosc 	VARCHAR(100),
	 ulica 	VARCHAR(100),
	 dom 	VARCHAR(100),
	 lokal 	VARCHAR(100),
	 kod_pocztowy 	VARCHAR(100),
	PRIMARY KEY(id_adres)
);

create table  ulica  (
	 id_woj  	INTEGER,
	 id_pow  	INTEGER,
	 id_gmi  	INTEGER,
	 symbol  	INTEGER,
	 symbol_pods  	INTEGER,
	 cecha  	VARCHAR(100),
	 nazwa_1  	VARCHAR(100),
	 nazwa_2  	VARCHAR(100),
	PRIMARY KEY(symbol)
);

create table  miejscowosc  (
	 id_woj  	INTEGER,
	 id_pow  	INTEGER,
	 id_gmi  	INTEGER,
	 symbol  	INTEGER,
	 symbol_pods  	INTEGER,
	 nazwa  	VARCHAR(100),
	PRIMARY KEY(symbol)
);

create table  powiat_gmina  (
	 id_powiat_gmina  	INTEGER,
	 id_woj  	INTEGER,
	 id_pow  	INTEGER,
	 id_gmi  	INTEGER,
	 nazwa  	INTEGER,
	 naz_dod  	INTEGER,
	PRIMARY KEY(id_woj,id_pow,id_gmi)
);

CREATE TABLE  kategoria_pytania  (
	 id_kategoria_pytania 	INTEGER,
	 nazwa 	VARCHAR(100),
	PRIMARY KEY(id_kategoria_pytania)
);

CREATE TABLE  pytanie  (
	 id_pytanie 	INTEGER,
	 tresc 	VARCHAR(100),
	id_ankieta INTEGER REFERENCES ankieta(id_ankieta),
	id_kategoria_pytania INTEGER REFERENCES kategoria_pytania(id_kategoria_pytania),
	PRIMARY KEY(id_pytanie)
);

CREATE TABLE  opcje  (
	 id_opcje 	INTEGER,
	 nazwa 	VARCHAR(100),
	id_pytanie INTEGER REFERENCES pytanie(id_pytanie),
	PRIMARY KEY(id_opcje)
);

CREATE TABLE  wynik_lista  (
	 id_wynik_lista 	INTEGER,
	 ilosc 	INTEGER,
	id_opcje INTEGER REFERENCES opcje(id_opcje),
	PRIMARY KEY(id_wynik_lista)
);

CREATE TABLE  wynik_bool  (
	 id_wynik_bool 	INTEGER,
	 tak 	INTEGER,
	 nie 	INTEGER,
	id_pytanie INTEGER REFERENCES pytanie(id_pytanie),
	PRIMARY KEY(id_wynik_bool)
);



CREATE TABLE mieszkaniec  (
	 id_mieszkaniec 	INTEGER,
	 pesel 	varchar(50),
	 imie 	varchar(50),
	 nazwisko 	varchar(50),
	 telefon 	varchar(50),
	 email 	varchar(50),
	PRIMARY KEY(id_mieszkaniec)
);



insert into mieszkaniec values (1,'74011804339','WOJCIECH','ROGOCKI','507291629','wojciech@wp.pl');
insert into mieszkaniec values (2,'44444444444','HELENA','REWA','6787561','hela@interia.pl');
insert into mieszkaniec values (3,'69090405252','ARTUR','URBANOWICZ','7405072','aurban@gmail.com');
insert into mieszkaniec values (4,'59040612948','EWA','JASZCZERSKA','728200274','ewusia@onet.eu');
insert into mieszkaniec values (5,'83080701353','MAREK','GULDA','602106007','marus@gulda.com');
insert into mieszkaniec values (6,'50121804481','JANINA','SIWIK','606760588','jadzka@wwp.pl');
insert into mieszkaniec values (7,'54121300114','MIROS£AW','ADAMCZYK','7781696','mirek2@gmail.com');
insert into mieszkaniec values (8,'49020901579','MARIA','CZAPIEWSKA','506800248','czesio@gmail.com');
insert into mieszkaniec values (9,'47051105391','ROMAN','ZIELIÑSKI','609231548','romus@buziaczek.pl');
insert into mieszkaniec values (10,'69060313321','IWONA','SIROCKA','587458621','iwonkasirocka@wp.pl');
insert into mieszkaniec values (11,'55041812097','BRONIS£AW','KO¯YCZKOWSKI','58454521','bronek@gmail.com');
insert into mieszkaniec values (12,'73071515065','MA£GORZATA','LAZAROWICZ','508717680','gosia@onet.eu');
insert into mieszkaniec values (13,'66070901908','ZOFIA','OKRÓJ','696319569','zofiaokroj@wp.pl');
insert into mieszkaniec values (14,'60052102235','ROMAN','FLISIKOWSKI','880289690','roman@gmail.com');
insert into mieszkaniec values (15,'75042212375','ROBERT','SZULC','604281245','roberto@microsoft.com');
insert into mieszkaniec values (16,'50051603165','SABINA','GERBATOWSKA','511037850','sabinka@wp.pl');
insert into mieszkaniec values (17,'55070716432','JÓZEF','SK£ADANOWSKI','668939665','jozef_sklad@gryf.com');
insert into mieszkaniec values (18,'46082006574','BRUNON','BANDZMER','548632147','brunon@bandzmer.com');
insert into mieszkaniec values (19,'59120708116','JANUSZ','POZAÑSKI','601667115','janusz@tafirma.com');
insert into mieszkaniec values (20,'48071907497','JAN','MIELEWCZYK','586690020','janek@szkola.pl');
insert into mieszkaniec values (21,'54011210376','ADAM','ŒWIGOÑSKI','48880855997','48788722500');
insert into mieszkaniec values (22,'62030510290','MIROS£AW','MELCER','513555388','miroslaw@gmail.com');
insert into mieszkaniec values (23,'53110402581','JOLANTA','KOPAÑSKA','0586771321','jolakopa@wp.pl');
insert into mieszkaniec values (24,'72021311683','WIOLETTA','ŒWIDERSKA-G£OWIENKA','668353852','wiolaœwider@interia.pl');
insert into mieszkaniec values (25,'78020308208','DOROTA','DOERING','796203540','dorota_doering@onet.eu');


insert into adres values (1,'Gdañsk','Szkolna','15', '2','84-250');
 insert into adres values (2,'Wejherowo','D³uga','1', '','84-200');
 insert into adres values (3,'Gdynia','Mickiewicza','2', '4','84-240');
 insert into adres values (4,'Rumia','Prosta','15', '','84-251');
 insert into adres values (5,'Reda','Jana Paw³a II','2', '','84-251');
 insert into adres values (6,'Tczew','G³ówna','57', '2','80-250');
 insert into adres values (7,'W³adys³awowo','Abrahama','10', '','80-014');
 insert into adres values (8,'Gniewino','Pomorska','7', '24','84-250');
 insert into adres values (9,'Luzino','Wolna','5', '','84-242');
 insert into adres values (10,'Orle','Grzybowa','8', '','84-252');
 insert into adres values (11,'Puck','Nowy Œwiat','5', '4/C','84-100');
 insert into adres values (12,'Puck','Abrahama','20', '16','84-100');
 insert into adres values (13,'Reda','Olimpijska','9', '39','84-240');
 insert into adres values (14,'Rumia','Wroc³awska','11', '35','84-230');
 insert into adres values (15,'Rumia','Sobieskiego','19', '44A','84-230');
 insert into adres values (16,'Strzebielino','Henryka Sienkiewicza','', '21B','84-220');
 insert into adres values (17,'Strzebielino','Piotra Skargi','', '9','84-220');
 insert into adres values (18,'Wejherowo','Jana III Sobieskiego','B/27', '350B','84-200');
 insert into adres values (19,'Wejherowo','Kaszubskie','54', '16','84-200');
 insert into adres values (20,'Bia³ogóra','Harcerska','7', '','84-113');
 insert into adres values (21,'Chynowie','','3', '','84-251');
 insert into adres values (22,'Dêbki','Bursztynowa','3', '','84-110');
 insert into adres values (23,'Dêbki','Morska','2', '','84-110');
 insert into adres values (24,'Gdynia','Kartuska','49', '46','84-002');
 insert into adres values (25,'Gdynia','Morska','19', '11','84-323');
 
insert into kategoria_pytania values (1,'tak/nie');
insert into kategoria_pytania values (2,'lista');



insert into pytanie values (1,'Czy jest pan/pani za budow¹ parku?',1,1);
insert into pytanie values (2,'Proszê wybraæ z listy co chcia³aby pan/pani by powsta³o.',2,2);
insert into pytanie values (3,'Proszê wybraæ przedstawiciela.',3,2);
insert into pytanie values (4,'Czy jest Pan/Pani zadowolony z naszych us³ug?',4,1);
insert into pytanie values (5,'Proszê wybraæ powód.',4,2);
insert into pytanie values (6,'Czy jest Pan/Pani zadowolony z procedury w Urzêdzie?',5,1);
insert into pytanie values (7,'Co by Pan/Pani zmieni³/a?',5,2);

 insert into opcje values (1,'park',2);
insert into opcje values (2,'plac zabaw',2);
insert into opcje values (3,'sklep spo¿ywczy',2);
insert into opcje values (4,'muzeum',2);


insert into opcje values (5,'Jan Matejko',3);
insert into opcje values (6,'Jadwiga Kazub',3);
insert into opcje values (7,'Krystian Mickiewicz',3);
insert into opcje values (8,'Anna Kowalska',3);



insert into opcje values (9,'Mi³a obs³uga',5);
insert into opcje values (10,'Szybki helpdesk',5);
insert into opcje values (11,'D³ugie oczekiwanie na rozwi¹zanie problemu',5);
insert into opcje values (12,'Wolno dzia³aj¹cy serwis',5);


insert into opcje values (13,'Obs³ugê',7);
insert into opcje values (14,'Czas oczekiwania na wnioski',7);
insert into opcje values (15,'Skrócenie kolejek',7);



insert into wynik_lista values (1,1,1);
insert into wynik_lista values (2,0,2);
insert into wynik_lista values (3,5,3);
insert into wynik_lista values (4,7,4);

insert into wynik_lista values (5,1,5);
insert into wynik_lista values (6,0,6);
insert into wynik_lista values (7,5,7);
insert into wynik_lista values (8,7,8);

insert into wynik_lista values (9,2,9);
insert into wynik_lista values (10,0,10);
insert into wynik_lista values (11,0,11);
insert into wynik_lista values (12,7,12);

insert into wynik_lista values (13,10,13);
insert into wynik_lista values (14,0,14);
insert into wynik_lista values (15,55,15);


insert into wynik_bool values (1,10,2,1);
insert into wynik_bool values (2,24,0,4);
insert into wynik_bool values (3,5,30,6);


commit;