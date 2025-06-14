//using Npgsql;
//using OrganizeAgenda.DTOs;

//namespace OrganizeAgenda.Repository
//{
//    /// <summary>
//    /// Repositório para operações de usuário utilizando PostgreSQL.
//    /// </summary>
//    public class UserRepository
//    {
//        private readonly string _connectionString;

//        /// <summary>
//        /// Inicializa uma nova instância de <see cref="UserRepository"/>.
//        /// </summary>
//        /// <param name="connectionString">String de conexão com o banco PostgreSQL.</param>
//        public UserRepository(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        /// <summary>
//        /// Retorna todos os usuários.
//        /// </summary>
//        public async Task<IEnumerable<UserDTO>> GetAllAsync()
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            const string sql = "SELECT id, name, email FROM users";
//            return await connection.QueryAsync<UserDTO>(sql);
//        }

//        /// <summary>
//        /// Retorna um usuário pelo ID.
//        /// </summary>
//        public async Task<UserDTO?> GetByIdAsync(int id)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            const string sql = "SELECT id, name, email FROM users WHERE id = @Id";
//            return await connection.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Id = id });
//        }

//        /// <summary>
//        /// Cria um novo usuário.
//        /// </summary>
//        public async Task<int> CreateAsync(UserDTO user)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            const string sql = @"
//                    INSERT INTO users (name, email)
//                    VALUES (@Name, @Email)
//                    RETURNING id;";
//            return await connection.ExecuteScalarAsync<int>(sql, user);
//        }

//        /// <summary>
//        /// Atualiza um usuário existente.
//        /// </summary>
//        public async Task<bool> UpdateAsync(UserDTO user)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            const string sql = @"
//                    UPDATE users
//                    SET name = @Name, email = @Email
//                    WHERE id = @Id";
//            var affected = await connection.ExecuteAsync(sql, user);
//            return affected > 0;
//        }

//        /// <summary>
//        /// Remove um usuário pelo ID.
//        /// </summary>
//        public async Task<bool> DeleteAsync(int id)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            const string sql = "DELETE FROM users WHERE id = @Id";
//            var affected = await connection.ExecuteAsync(sql, new { Id = id });
//            return affected > 0;
//        }
//    }
//}
