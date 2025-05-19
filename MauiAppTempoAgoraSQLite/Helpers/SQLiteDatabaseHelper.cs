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
        // Conexão assíncrona com o banco de dados SQLite
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
        public Task<int> Insert(Tempo p)
        {
            return _conn.InsertAsync(p);
        }

        /// Atualiza um produto existente no banco de dados


        /// Remove um produto do banco de dados
        public Task<int> Delete(int id)
        {
            return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
        }

        /// Obtém todos os produtos do banco de dados
        public Task<List<Tempo>> GetAll()
        {
            return _conn.Table<Tempo>().ToListAsync();
        }

        /// Busca produtos pela descrição
        public Task<List<Tempo>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE description LIKE '%" + q + "%'";

            return _conn.QueryAsync<Tempo>(sql);
        }
    }
}
