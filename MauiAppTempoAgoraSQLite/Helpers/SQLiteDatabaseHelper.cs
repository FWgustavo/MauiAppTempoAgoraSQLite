using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppTempoAgoraSQLite.Models;
using SQLite;

namespace MauiAppTempoAgoraSQLite.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        /// Construtor que inicializa a conexão e cria a tabela se não existir
        public SQLiteDatabaseHelper(string path)
        {
            // Inicializa a conexão assíncrona com o banco de dados
            _conn = new SQLiteAsyncConnection(path);
            // Cria a tabela Produto se não existir
            _conn.CreateTableAsync<Tempo>().Wait();
        }

        /// Insere um novo produto no banco de dados
        public Task<int> Insert(Tempo temp)
        {
            return _conn.InsertAsync(temp);
        }
    }
}
