using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class LeS : IEntity
    {
        public int IdLekar { get; set; }
        public int IdSertifikat { get; set; }
        public DateTime DatumIzdavanja { get; set; }

        public string TableName => "les";
        public string Values => $"{IdLekar}, {IdSertifikat}, '{DatumIzdavanja}'";
        public string SetClause => $"idLekar = {IdLekar}, idSertifikat = {IdSertifikat}, datumIzdavanja = '{DatumIzdavanja}'";
        public string PrimaryKey => $"idLekar, idSertifikat";

        public string PrimaryKeyCondition => $"idLekar = {IdLekar} AND idSertifikat = {IdSertifikat}";
        public string Prikaz => $"{DatumIzdavanja}";

        public string Criteria { get; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lesLista = new List<IEntity>();
            while (reader.Read())
            {
                LeS les = new LeS
                {
                    IdLekar = (int)reader["idLekar"],
                    IdSertifikat = (int)reader["idSertifikat"],
                    DatumIzdavanja = (DateTime)reader["datumIzdavanja"],
                };
                lesLista.Add(les);
            }
            return lesLista;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}