namespace OrganizeAgenda.Utils
{
    /// <summary>
    /// Contém as rotas da API utilizadas no sistema.
    /// </summary>
    public class ApiRoutes
    {
        public const string Api = "api/";

        public const string Version = "v1/";

        /// <summary>
        /// Rota base da API, combinando o prefixo e a versão.
        /// </summary>
        public const string Base = Api + Version;

        /// <summary>
        /// Rotas relacionadas às operações de usuário.
        /// </summary>
        public static class User
        {
            /// <summary>
            /// Rota para obter todos os usuários.
            /// </summary>
            public const string GetAll = Base + "api/user";

            /// <summary>
            /// Rota para obter um usuário pelo ID.
            /// </summary>
            public const string GetById = Base + "api/user/{id}";

            /// <summary>
            /// Rota para criar um novo usuário.
            /// </summary>
            public const string Create = Base + "api/user";

            /// <summary>
            /// Rota para atualizar um usuário existente.
            /// </summary>
            public const string Update = Base + "api/user/{id}";

            /// <summary>
            /// Rota para deletar um usuário.
            /// </summary>
            public const string Delete = Base + "api/user/{id}";
        }
    }
}
