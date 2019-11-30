using System;
using SQLite;

namespace SQliteSample
{
    [Table("Items")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario() { }
    }
}
