using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace Common.Domain
{
    public class Pacijent : ICrudEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public Mesto Mesto { get; set; }

        public string TableName => "pacijent";
        public string ClassNameAccusativeSingular => "pacijenta";
        public string ClassNameAccusativePlural => "pacijente";

        public string Columns => "ime, prezime, email, idMesto";

        public string ValuesClause => "@Ime, @Prezime, @Email, @IdMesto";

        public string SetClause => "ime = @Ime, prezime = @Prezime, email = @Email, idMesto = @IdMesto";

        public string PrimaryKey => "idPacijent";

        public string PrimaryKeyCondition => "idPacijent = @Id";

        public string JoinTableName => "pacijent p JOIN mesto m ON p.idMesto = m.idMesto";

        public string SelectClause =>
            "p.idPacijent, p.ime, p.prezime, p.email, " +
            "p.idMesto AS PacijentIdMesto, " +
            "m.idMesto AS MestoId, m.naziv AS MestoNaziv, m.postanskiBroj AS MestoPostanskiBroj";

        public string DisplayValue => $"{Ime} {Prezime}";

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (Id > 0)
            {
                conditions.Add("p.idPacijent = @Id");
                parameters.Add(new SqlParameter("@Id", Id));
            }

            if (!string.IsNullOrWhiteSpace(Ime))
            {
                conditions.Add("p.ime LIKE @Ime");
                parameters.Add(new SqlParameter("@Ime", $"%{Ime}%"));
            }

            if (!string.IsNullOrWhiteSpace(Prezime))
            {
                conditions.Add("p.prezime LIKE @Prezime");
                parameters.Add(new SqlParameter("@Prezime", $"%{Prezime}%"));
            }

            if (Mesto != null && Mesto.Id > 0)
            {
                conditions.Add("p.idMesto = @IdMesto");
                parameters.Add(new SqlParameter("@IdMesto", Mesto.Id));
            }

            return (conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1", parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Pacijent
                {
                    Id = (int)reader["idPacijent"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Email = (string)reader["email"],
                    Mesto = new Mesto
                    {
                        Id = (int)reader["MestoId"],
                        Naziv = (string)reader["MestoNaziv"],
                        PostanskiBroj = (string)reader["MestoPostanskiBroj"]
                    }
                });
            }
            return lista;
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Ime", Ime),
                new SqlParameter("@Prezime", Prezime),
                new SqlParameter("@Email", Email),
                new SqlParameter("@IdMesto", Mesto?.Id ?? (object)DBNull.Value)
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
