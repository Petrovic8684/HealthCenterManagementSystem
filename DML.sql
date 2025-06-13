INSERT INTO Lekar(ime, prezime, email, sifra) VALUES('Jovan', 'Petrović', 'jovan8684@gmail.com', 'sifra123');
INSERT INTO Lekar(ime, prezime, email, sifra) VALUES('Biljana', 'Petrović', 'bilja369@gmail.com', 'sifra321');

SELECT * FROM lekar WHERE email='jovan8684@gmail.com' AND sifra='sifra123';