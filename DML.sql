INSERT INTO Dijagnoza (naziv, opis, bazniSkor) VALUES 
(N'Hipertenzija', N'Hronično povišen krvni pritisak. Povećava rizik od srčanih bolesti.', 120),
(N'Dijabetes tip 2', N'Hronično stanje poremećenog metabolizma glukoze zbog insulinske rezistencije.', 150),
(N'Hiperlipidemija', N'Povišen nivo masnoća (lipida) u krvi, uključujući holesterol i trigliceride.', 100),
(N'Astma', N'Hronična upalna bolest disajnih puteva, izaziva otežano disanje i kašalj.', 130),
(N'Hronični bronhitis', N'Dugotrajan kašalj sa sluzavim iskašljavanjem, najčešće kod pušača.', 160),
(N'Depresivni poremećaj', N'Ponavljajući epizodični poremećaj raspoloženja sa gubitkom interesa i energije.', 140),
(N'Anksiozni poremećaj', N'Povećana briga, napetost i fizički simptomi poput ubrzanog pulsa.', 110),
(N'Gastritis', N'Upala sluzokože želuca, često izazvana infekcijom, stresom ili lekovima.', 90),
(N'Osteoartritis', N'Degenerativna bolest zglobova, uzrokuje bol i ukočenost, najčešće kolena i kukovi.', 125),
(N'Refluks', N'Povratak želudačne kiseline u jednjak, izaziva gorušicu i nelagodnost.', 80);

INSERT INTO Lekar (ime, prezime, email, korisnickoIme, sifra) VALUES
(N'Jovan', N'Petrovic', N'jovan8684@gmail.com', N'joca', N'pygXu0J+tFD3cPNgaXwCON8Ji7rDV1D+VE55QoqvwM+G6YRvpYm30Aq9iNv0/+v8'),
(N'Jelena', N'Miladinović', N'jelena.miladinovic@klinika.rs', N'jmil_med', N'lxZePxSPV9hVv7GLhHKTmjyFNBv1vbxzT49NzLk1mtQNbyJqm7/msIFXhE7If7w2'),
(N'Marko', N'Kostić', N'marko.kostic@klinika.rs', N'mkostic', N'MuJ2JVP9jzkQOyklCWKDfqm4Uy2usPvFMnCZAyNwi/54LpcCzdIlRHiHMhknmxLg'),
(N'Ana', N'Milutinović', N'ana.milutinovic@klinika.rs', N'amil_psih', N'4lDZSqbOr3JRHepI5s9gTN0Lx0GOO7J5KVEJTI3t1hJ2RrUXBkEDWy4TORLgAg3Y');

INSERT INTO Sertifikat (opis) VALUES
(N'Specijalizacija iz interne medicine (ABIM)'),
(N'Specijalizacija iz endokrinologije (EDM)'),
(N'Specijalizacija iz pulmologije (ABP)'),
(N'Sertifikat iz kliničke psihijatrije (ABPN)'),
(N'Licenca za edukatora u dijabetesu (CDCES)');

INSERT INTO Mesto (naziv, postanskiBroj) VALUES
(N'Beograd', N'11000'),
(N'Novi Sad', N'21000'),
(N'Niš', N'18000'),
(N'Kragujevac', N'34000'),
(N'Jagodina', N'35000'),
(N'Subotica', N'24000');

INSERT INTO Pacijent (ime, prezime, email, idMesto) VALUES
(N'Marko', N'Jovanović', N'marko.jovanovic@gmail.com', 1),
(N'Ana', N'Petrović', N'ana.petrovic.ns@gmail.com', 2),
(N'Nikola', N'Ilić', N'nikola.ilic1800@gmail.com', 3),
(N'Marija', N'Stanković', N'marija.stankovic@gmail.com', 5),
(N'Luka', N'Popović', N'luka.popovic.kg@yahoo.com', 4),
(N'Jelena', N'Kovačević', N'jelena.kovac@mail.com', 6),
(N'Ivana', N'Milenković', N'ivana.milenkovic@gmail.com', 1),
(N'Stefan', N'Đorđević', N'stefan.djordjevic@gmail.com', 2),
(N'Tamara', N'Nikolić', N'tamara.nikolić@outlook.com', 3),
(N'Miloš', N'Simić', N'milos.simic@yahoo.com', 5),
(N'Katarina', N'Ristić', N'katarina.ristic@gmail.com', 4),
(N'Nenad', N'Lazić', N'nenad922@gmail.com', 6),
(N'Bojana', N'Pavlović', N'bojana.pav223@gmail.com', 1),
(N'Aleksandar', N'Stevanović', N'aca.stevanovic@outlook.com', 2),
(N'Milica', N'Tomić', N'milica.tomic@gmail.com', 3),
(N'Goran', N'Radovanović', N'goran827@gmail.com', 5),
(N'Teodora', N'Živanović', N'teodorakg@mail.com', 4),
(N'Vladimir', N'Blagojević', N'vblagojevic@outlook.com', 6),
(N'Sofija', N'Janković', N'sofija23112@gmail.com', 1),
(N'Nemanja', N'Maksimović', N'nemanjam@gmail.com', 2),
(N'Andrej', N'Vučković', N'andrejvuckovic9211@gmail.com', 3);

INSERT INTO ZdravstveniKarton (datumOtvaranja, napomena, ukupniSkor, stanje, idLekar, idPacijent) VALUES
(CAST(N'2025-06-20' AS Date), N'Pacijent sa povišenim pritiskom, preporučena promena životnih navika.', 224, N'Lakše bolestan', 2, 2),
(CAST(N'2025-06-20' AS Date), N'Kontrola nivoa šećera u krvi i edukacija o dijabetesu.', 285, N'Lakše bolestan', 2, 3),
(CAST(N'2025-06-20' AS Date), N'Periodični problemi sa disanjem, preporučena dodatna pulmološka dijagnostika.', 345, N'Lakše bolestan', 3, 4),
(CAST(N'2025-06-20' AS Date), N'Simptomi depresije, započeta terapija i psihoterapija.', 306, N'Lakše bolestan', 4, 5),
(CAST(N'2025-06-20' AS Date), N'Praćenje refluksa i predložena dijeta.', 80, N'Zdrav', 3, 6);

INSERT INTO StavkaZdravstvenogKartona (idZdravstveniKarton, datumUpisa, ponder, skor, idDijagnoza) VALUES
(1, CAST(N'2025-06-20' AS Date), 1.2, 144, 1),
(1, CAST(N'2025-06-20' AS Date), 0.8, 80, 3),
(2, CAST(N'2025-06-20' AS Date), 1.5, 225, 2),
(2, CAST(N'2025-06-20' AS Date), 0.6, 60, 3),
(3, CAST(N'2025-06-20' AS Date), 1.3, 169, 4),
(3, CAST(N'2025-06-20' AS Date), 1.1, 176, 5),
(4, CAST(N'2025-06-20' AS Date), 1.4, 196, 6),
(4, CAST(N'2025-06-20' AS Date), 1, 110, 7),
(5, CAST(N'2025-06-20' AS Date), 1, 80, 10);

INSERT INTO LeS (idLekar, idSertifikat, datumIzdavanja) VALUES
(2, 1, CAST(N'2025-06-20' AS Date)),
(2, 5, CAST(N'2025-06-20' AS Date)),
(3, 1, CAST(N'2025-06-20' AS Date)),
(3, 3, CAST(N'2025-06-20' AS Date)),
(4, 4, CAST(N'2025-06-20' AS Date));