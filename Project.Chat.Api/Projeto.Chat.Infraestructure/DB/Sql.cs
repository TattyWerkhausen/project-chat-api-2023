namespace Projeto.Chat.Infraestructure.DB
{
    public class Sql
    {
        private readonly Database _database;
        public Sql(Database database)
        {
            _database = database;   
        }
       // string connection = _database.ObterConnection();
    }
}
