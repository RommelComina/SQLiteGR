﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteJossuePalacios
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
