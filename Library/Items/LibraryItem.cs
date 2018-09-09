﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

/// <summary>
/// The main namespace
/// </summary>
namespace Library
{
    /// <summary>
    /// The base Class for almost everything in this library.
    /// </summary>
    public class LibraryItem : Entity, ISavable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryItem"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        public LibraryItem(string name) : base(name)
        {
            Database database = new Database();
            _id = database.GetLastInsertedID(TABLE_NAME) + 1;
            database.Dispose();
        }

        public LibraryItem(int id, string name) : base(name, id)
        {
        }

        /// <summary>
        /// The table name
        /// </summary>
        public override string TABLE_NAME => "Items";

        #region Database Stuff

        /// <summary>
        /// Loads this instance from db.
        /// </summary>
        /// <param name="ident"></param>
        public static LibraryItem Load(SQLiteDataReader reader)
        {
            LibraryItem item = null;
            if (reader.HasRows)
            {
                reader.Read();
                int _id = (int)(long)reader["ID"];
                string _name = (string)reader["Name"];
                item = new LibraryItem(_id, _name);
                reader.Close();
            }
            return item;
        }

        /// <summary>
        /// Saves this instance to db.
        /// </summary>
        public override void Save()
        {
            List<string> colVals = new List<string>() { _id.ToString(), _name };
            Database database = new Database();
            database.Save(TABLE_NAME, COL_NAMES, colVals);
        }

        #endregion Database Stuff
    }
}