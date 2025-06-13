CREATE TABLE Lekar (
    idLekar INT IDENTITY(1,1) PRIMARY KEY,
    ime NVARCHAR(100) NOT NULL,
    prezime NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL CHECK (email LIKE '%@%'),
	sifra CHAR(64) NOT NULL
);

CREATE TABLE Dijagnoza (
    idDijagnoza INT IDENTITY(1,1) PRIMARY KEY,
    naziv NVARCHAR(100) NOT NULL,
    opis NVARCHAR(255) NOT NULL,
    bazniSkor FLOAT NOT NULL CHECK (bazniSkor > 0)
);

CREATE TABLE Mesto (
    idMesto INT IDENTITY(1,1) PRIMARY KEY,
    naziv NVARCHAR(100) NOT NULL,
    postanskiBroj CHAR(5) NOT NULL CHECK (postanskiBroj LIKE '[0-9][0-9][0-9][0-9][0-9]')
);

CREATE TABLE Sertifikat (
    idSertifikat INT IDENTITY(1,1) PRIMARY KEY,
    opis NVARCHAR(255) NOT NULL
);

CREATE TABLE Pacijent (
    idPacijent INT IDENTITY(1,1) PRIMARY KEY,
    ime NVARCHAR(100) NOT NULL,
    prezime NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL CHECK (email LIKE '%@%'),
    idMesto INT NOT NULL CHECK (idMesto > 0),
    FOREIGN KEY (idMesto) REFERENCES Mesto(idMesto) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE ZdravstveniKarton (
    idZdravstveniKarton INT IDENTITY(1,1) PRIMARY KEY,
    datumOtvaranja DATE NOT NULL,
    napomena NVARCHAR(255) NOT NULL,
    ukupniSkor FLOAT NOT NULL DEFAULT 0,
    stanje NVARCHAR(20) NOT NULL CHECK (stanje IN ('Zdrav', 'Lakše bolestan', 'Teže bolestan')),
    idLekar INT NOT NULL CHECK (idLekar > 0),
    idPacijent INT NOT NULL CHECK (idPacijent > 0),
    FOREIGN KEY (idLekar) REFERENCES Lekar(idLekar) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (idPacijent) REFERENCES Pacijent(idPacijent) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE StavkaZdravstvenogKartona (
    idZdravstveniKarton INT NOT NULL CHECK (idZdravstveniKarton > 0),
    rb INT IDENTITY(0,1),
    datumUpisa DATE NOT NULL,
    ponder FLOAT NOT NULL DEFAULT 1 CHECK (ponder >= 1),
	skor FLOAT NOT NULL DEFAULT 0,
	idDijagnoza INT NOT NULL CHECK (idDijagnoza > 0),
    PRIMARY KEY (idZdravstveniKarton, rb),
    FOREIGN KEY (idZdravstveniKarton) REFERENCES ZdravstveniKarton(idZdravstveniKarton) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (idDijagnoza) REFERENCES Dijagnoza(idDijagnoza) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE LeS (
    idLekar INT NOT NULL CHECK (idLekar > 0),
    idSertifikat INT NOT NULL CHECK (idSertifikat > 0),
    datumIzdavanja DATE NOT NULL,
    PRIMARY KEY (idLekar, idSertifikat),
    FOREIGN KEY (idLekar) REFERENCES Lekar(idLekar) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (idSertifikat) REFERENCES Sertifikat(idSertifikat) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TRIGGER trg_AzuriranjeSkor
ON StavkaZdravstvenogKartona
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE szk
    SET skor = szk.ponder * d.bazniSkor
    FROM StavkaZdravstvenogKartona szk
    INNER JOIN inserted i ON szk.idZdravstveniKarton = i.idZdravstveniKarton AND szk.rb = i.rb
    INNER JOIN Dijagnoza d ON szk.idDijagnoza = d.idDijagnoza;
END;

CREATE TRIGGER trg_AzuriranjeUkupniSkorStanje
ON StavkaZdravstvenogKartona
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AffectedKartons TABLE (idZdravstveniKarton INT PRIMARY KEY);

    INSERT INTO @AffectedKartons(idZdravstveniKarton)
    SELECT idZdravstveniKarton FROM inserted
    UNION
    SELECT idZdravstveniKarton FROM deleted;

    UPDATE zk
    SET 
        ukupniSkor = ISNULL(suma.sumaSkor, 0),
        stanje = CASE
                    WHEN ISNULL(suma.sumaSkor, 0) <= 100 THEN 'Zdrav'
                    WHEN ISNULL(suma.sumaSkor, 0) <= 500 THEN 'Lakše bolestan'
                    ELSE 'Teže bolestan'
                 END
    FROM ZdravstveniKarton zk
    INNER JOIN @AffectedKartons ak ON zk.idZdravstveniKarton = ak.idZdravstveniKarton
    LEFT JOIN (
        SELECT idZdravstveniKarton, SUM(skor) AS sumaSkor
        FROM StavkaZdravstvenogKartona
        GROUP BY idZdravstveniKarton
    ) suma ON zk.idZdravstveniKarton = suma.idZdravstveniKarton;
END;
