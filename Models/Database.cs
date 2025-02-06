using DBUtils.Models;
using System;
using System.Collections.Generic;

namespace DBUtils.Models
{
    /// <summary>
    /// Obtém ou define a base de dados
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Obtém ou define o nome do banco de dados
        /// </summary>
        public string? DatabaseName { get; set; }

        /// <summary>
        /// Obtém ou define os schemas e suas tabelas
        /// </summary>
        public List<Schema>? Schemas { get; set; }

        /// <summary>
        /// Obtém ou define as contraints
        /// </summary>
        public List<Constraint>? Constraints { get; set; }

        /// <summary>
        /// Obtém ou define os indices
        /// </summary>
        public List<Index>? Indexes { get; set; }

        /// <summary>
        /// Obtém ou define as procedures
        /// </summary>
        public List<Procedure>? Procedures { get; set; }

        /// <summary>
        /// Obtém ou define as funções
        /// </summary>
        public List<Function>? Functions { get; set; }

        /// <summary>
        /// Obtém ou define as triggers
        /// </summary>
        public List<Trigger>? Triggers { get; set; }

        /// <summary>
        /// Obtém ou define as Views
        /// </summary>
        public List<View>? Views { get; set; }
    }

    /// <summary>
    /// Obtém ou define os schemas
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Obtém ou define o nome do Schema
        /// </summary>
        public string? SchemaName { get; set; }

        /// <summary>
        /// Obtém ou define as tabelas do schema
        /// </summary>
        public List<Table>? Tables { get; set; }
    }

    /// <summary>
    /// Obtém ou define a estrura das tabelas
    /// </summary>
    public class Table
    {
        public string? Name { get; set; } // Nome da tabela
        public List<Column>? Columns { get; set; } // Lista de colunas da tabela
        public List<Index>? Indexes { get; set; } // Lista de índices associados à tabela
    }

    public class Column
    {
        
        public string? Column_name { get; set; } // Nome da coluna
        public string? Type { get; set; } // Tipo de dado (ex: INT, VARCHAR)
        public bool Computed { get; set; } // Coluna computada
        public string? Length { get; set; } // Comprimento máximo para tipos como VARCHAR
        public int? Precision { get; set; } // Precisão para tipos como DECIMAL
        public int? Scale { get; set; } // Escala para tipos como DECIMAL
        public bool Nullable { get; set; } // Se a coluna permite NULL
        public string? TrimTrailingBlanks { get; set; }
        public string? FixedLenNullInSource { get; set; }
        public string? Collation { get; set; }
        public bool IsIdentity { get; set; } // Se a coluna é identidade (auto incremento)
    }

    public class Index
    {
        public string? IndexName { get; set; } // Nome do índice
        public List<string>? Columns { get; set; } // Colunas que fazem parte do índice
        public bool IsUnique { get; set; } // Se o índice é único
    }

    public class Constraint
    {
        public string? TableName { get; set; } // Nome da tabela que a restrição pertence
        public string? ConstraintName { get; set; } // Nome da restrição
        public string? ConstraintType { get; set; } // Tipo de restrição (PRIMARY KEY, FOREIGN KEY, etc.)
        public string? ReferencedTable { get; set; } // Nome da tabela referenciada (para foreign keys)
        public string? ColumnName { get; set; } // Nome da coluna da restrição
        public string? ReferencedColumn { get; set; } // Nome da coluna referenciada (para foreign keys)
    }

    public class Procedure
    {
        public string? Name { get; set; } // Nome da procedure
        public string? Definition { get; set; } // Definição SQL da procedure
    }

    public class Function
    {
        public string? Name { get; set; } // Nome da função
        public string? Definition { get; set; } // Definição SQL da função
    }

    public class Trigger
    {
        public string? Name { get; set; } // Nome da trigger
        public string? Definition { get; set; } // Definição SQL da trigger
    }

    public class View
    {
        public string? Name { get; set; } // Nome da procedure
        public string? Definition { get; set; } // Definição SQL da procedure
    }

    public class DatabaseStructure
    {
        public Database? Database { get; set; } // Objeto do banco de dados
    }
}