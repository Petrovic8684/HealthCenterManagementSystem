using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public class ZdravstveniKarton : ICrudEntity
    {
        public int Id { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public string Napomena { get; set; }
        public string Stanje { get; set; }
        public double UkupniSkor { get; set; }
        public Lekar Lekar { get; set; } = new();
        public Pacijent Pacijent { get; set; } = new();
        public List<StavkaZdravstvenogKartona> Stavke { get; set; } = new();

        public string TableName => "ZdravstveniKarton";

        public string ClassNameAccusativeSingular => "zdravstveni karton";
        public string ClassNameAccusativePlural => "zdravstvene kartone";

        public string JoinTableName =>
            @"ZdravstveniKarton zk
              JOIN Lekar l ON zk.idLekar = l.idLekar
              JOIN Pacijent p ON zk.idPacijent = p.idPacijent
              JOIN Mesto m ON p.idMesto = m.idMesto
              LEFT JOIN StavkaZdravstvenogKartona sz ON zk.idZdravstveniKarton = sz.idZdravstveniKarton
              LEFT JOIN Dijagnoza d ON sz.idDijagnoza = d.idDijagnoza";

        public string SelectClause =>
            @"zk.idZdravstveniKarton, zk.datumOtvaranja, zk.napomena, zk.ukupniSkor, zk.stanje,
              l.idLekar, l.ime AS imeLekara, l.prezime AS prezimeLekara, l.email AS emailLekara,
              p.idPacijent, p.ime AS imePacijenta, p.prezime AS prezimePacijenta, p.email AS emailPacijenta,
              m.idMesto, m.naziv AS nazivMesta, m.postanskiBroj,
              sz.rb, sz.datumUpisa, sz.ponder, sz.skor,
              d.idDijagnoza, d.naziv AS nazivDijagnoze, d.opis AS opisDijagnoze, d.bazniSkor";

        public string Columns => "datumOtvaranja, napomena, idLekar, idPacijent";

        public string ValuesClause => "@DatumOtvaranja, @Napomena, @IdLekar, @IdPacijent";

        public string SetClause => "datumOtvaranja=@DatumOtvaranja, napomena=@Napomena, idLekar=@IdLekar, idPacijent=@IdPacijent";

        public string PrimaryKey => "idZdravstveniKarton";

        public string PrimaryKeyCondition => "idZdravstveniKarton = @Id";

        public string DisplayValue => $"ZK #{Id} - {Stanje}";

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if(Id > 0)
            {
                conditions.Add("zk.idZdravstveniKarton = @Id");
                parameters.Add(new SqlParameter("@Id", Id));
            }

            if (Pacijent?.Ime is not null)
            {
                conditions.Add("p.ime LIKE @ImePacijent");
                parameters.Add(new SqlParameter("@ImePacijent", $"%{Pacijent.Ime}%"));
            }

            if (Lekar?.Ime is not null)
            {
                conditions.Add("l.ime LIKE @ImeLekar");
                parameters.Add(new SqlParameter("@ImeLekar", $"%{Lekar.Ime}%"));
            }

            if (DatumOtvaranja > DateTime.MinValue)
            {
                conditions.Add("zk.datumOtvaranja >= @DatumOtvaranja");
                parameters.Add(new SqlParameter("@DatumOtvaranja", DatumOtvaranja));
            }

            if (Stavke?.Count > 0 && Stavke[0]?.Dijagnoza?.Id != -1)
            {
                conditions.Add("d.idDijagnoza = @IdDijagnoza");
                parameters.Add(new SqlParameter("@IdDijagnoza", Stavke[0].Dijagnoza.Id));
            }

            return (conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1", parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var mapa = new Dictionary<int, ZdravstveniKarton>();

            while (reader.Read())
            {
                int zkId = (int)reader["idZdravstveniKarton"];

                if (!mapa.ContainsKey(zkId))
                {
                    var zk = new ZdravstveniKarton
                    {
                        Id = zkId,
                        DatumOtvaranja = (DateTime)reader["datumOtvaranja"],
                        Napomena = (string)reader["napomena"],
                        UkupniSkor = (double)reader["ukupniSkor"],
                        Stanje = (string)reader["stanje"],

                        Lekar = new Lekar
                        {
                            Id = (int)reader["idLekar"],
                            Ime = (string)reader["imeLekara"],
                            Prezime = (string)reader["prezimeLekara"],
                            Email = (string)reader["emailLekara"]
                        },
                        Pacijent = new Pacijent
                        {
                            Id = (int)reader["idPacijent"],
                            Ime = (string)reader["imePacijenta"],
                            Prezime = (string)reader["prezimePacijenta"],
                            Email = (string)reader["emailPacijenta"],
                            Mesto = new Mesto
                            {
                                Id = (int)reader["idMesto"],
                                Naziv = (string)reader["nazivMesta"],
                                PostanskiBroj = (string)reader["postanskiBroj"]
                            }
                        },
                        Stavke = new List<StavkaZdravstvenogKartona>()
                    };

                    mapa.Add(zkId, zk);
                }

                if (reader["rb"] != DBNull.Value)
                {
                    mapa[zkId].Stavke.Add(new StavkaZdravstvenogKartona
                    {
                        RedniBroj = (int)reader["rb"],
                        DatumUpisa = (DateTime)reader["datumUpisa"],
                        Ponder = (double)reader["ponder"],
                        Skor = (double)reader["skor"],
                        Dijagnoza = new Dijagnoza
                        {
                            Id = (int)reader["idDijagnoza"],
                            Naziv = (string)reader["nazivDijagnoze"],
                            Opis = (string)reader["opisDijagnoze"],
                            BazniSkor = (double)reader["bazniSkor"]
                        }
                    });
                }
            }

            return new List<IEntity>(mapa.Values);
        }

        public List<SqlParameter> GetSqlParameters() => new()
        {
            new SqlParameter("@Id", Id),
            new SqlParameter("@DatumOtvaranja", DatumOtvaranja),
            new SqlParameter("@Napomena", Napomena ?? (object)DBNull.Value),
            new SqlParameter("@IdLekar", Lekar?.Id ?? (object)DBNull.Value),
            new SqlParameter("@IdPacijent", Pacijent?.Id ?? (object)DBNull.Value),
        };

        public List<SqlParameter> GetPrimaryKeyParameters() =>
            new() { new SqlParameter("@Id", Id) };

        public override string ToString() => DisplayValue;
    }
}
