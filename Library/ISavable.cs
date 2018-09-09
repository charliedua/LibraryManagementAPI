﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Library
{
    public interface ISavable
    {
        /// <summary>
        /// Saves this instance to db.
        /// </summary>
        void Save();
    }
}