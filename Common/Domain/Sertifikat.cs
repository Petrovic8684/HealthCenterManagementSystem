using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Sertifikat : ICrudEntity
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        public string TableName => "sertifikat";
        public string Values => $"'{Opis}'";
        public string SetClause => $"opis = '{Opis}'";
        public string PrimaryKey => $"idSertifikat";
        public string PrimaryKeyCondition => $"idSertifikat = {Id}";
        public string Prikaz => $"{Opis}";

        public string Criteria
        {
            get
            {
                var criteria = new List<string>();

                if (!string.IsNullOrWhiteSpace(Opis))
                    criteria.Add($"opis LIKE '%{Opis}%'");

                return criteria.Count > 0 ? string.Join(" AND ", criteria) : "1=1";
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> sertifikati = new List<IEntity>();
            while (reader.Read())
            {
                Sertifikat sertifikat = new Sertifikat
                {
                    Id = (int)reader["idSertifikat"],
                    Opis = (string)reader["opis"],
                };
                sertifikati.Add(sertifikat);
            }
            return sertifikati;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}
