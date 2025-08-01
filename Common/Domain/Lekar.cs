using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Lekar : ICrudEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public List<Sertifikat> Sertifikati { get; set; } = new List<Sertifikat>();

        public string TableName => "lekar";
        public string ClassNameAccusativeSingular => "lekara";
        public string ClassNameAccusativePlural => "lekare";

        public string Columns => "ime, prezime, email, sifra, korisnickoIme";

        public string ValuesClause => "@Ime, @Prezime, @Email, @Sifra, @KorisnickoIme";

        public string SetClause => "ime = @Ime, prezime = @Prezime, email = @Email";

        public string PrimaryKey => "idLekar";

        public string PrimaryKeyCondition => "idLekar = @Id";

        public string DisplayValue => $"{Ime} {Prezime}";

        public string JoinTableName =>
            "lekar l " +
            "LEFT JOIN les les ON l.idLekar = les.idLekar " +
            "LEFT JOIN sertifikat s ON les.idSertifikat = s.idSertifikat";

        public string SelectClause =>
            "l.idLekar, l.ime, l.prezime, l.email, l.sifra, l.korisnickoIme, " +
            "s.idSertifikat AS SertifikatId, s.opis AS SertifikatOpis";

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (Id > 0)
            {
                conditions.Add("l.idLekar = @Id");
                parameters.Add(new SqlParameter("@Id", Id));
            }

            if (!string.IsNullOrWhiteSpace(Ime))
            {
                conditions.Add("l.ime LIKE @Ime");
                parameters.Add(new SqlParameter("@Ime", $"%{Ime}%"));
            }

            if (!string.IsNullOrWhiteSpace(Prezime))
            {
                conditions.Add("l.prezime LIKE @Prezime");
                parameters.Add(new SqlParameter("@Prezime", $"%{Prezime}%"));
            }

            if (!string.IsNullOrWhiteSpace(Email))
            {
                conditions.Add("l.email = @Email");
                parameters.Add(new SqlParameter("@Email", Email));
            }

            if (!string.IsNullOrWhiteSpace(KorisnickoIme))
            {
                conditions.Add("l.korisnickoIme = @KorisnickoIme");
                parameters.Add(new SqlParameter("@KorisnickoIme", KorisnickoIme));
            }

            if (Sertifikati?.Count > 0 && Sertifikati[0]?.Id > 0)
            {
                conditions.Add("l.idLekar IN (SELECT idLekar FROM les WHERE idSertifikat = @IdSertifikat)");
                parameters.Add(new SqlParameter("@IdSertifikat", Sertifikati[0].Id));
            }

            return (conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1", parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var lekari = new List<IEntity>();
            var lekarDict = new Dictionary<int, Lekar>();

            while (reader.Read())
            {
                int idLekar = (int)reader["idLekar"];

                if (!lekarDict.TryGetValue(idLekar, out var lekar))
                {
                    lekar = new Lekar
                    {
                        Id = idLekar,
                        Ime = (string)reader["ime"],
                        Prezime = (string)reader["prezime"],
                        Email = (string)reader["email"],
                        Sifra = (string)reader["sifra"],
                        KorisnickoIme = (string)reader["korisnickoIme"],
                        Sertifikati = new List<Sertifikat>()
                    };
                    lekarDict[idLekar] = lekar;
                }

                if (reader["SertifikatId"] != DBNull.Value)
                {
                    var sertifikat = new Sertifikat
                    {
                        Id = (int)reader["SertifikatId"],
                        Opis = (string)reader["SertifikatOpis"]
                    };

                    if (!lekar.Sertifikati.Exists(s => s.Id == sertifikat.Id))
                        lekar.Sertifikati.Add(sertifikat);
                }
            }

            lekari.AddRange(lekarDict.Values);
            return lekari;
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Ime", Ime),
                new SqlParameter("@Prezime", Prezime),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Sifra", Sifra),
                new SqlParameter("@KorisnickoIme", KorisnickoIme),
            };
        }

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
        }

        public override string ToString() => DisplayValue;
    }
}
