﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public enum AjaxStatu
    {
        none =0,
        ok,
        err,
        nologin,
        nopermission
    }


    public enum SortDirection
    {
        Ascending =0,
        Descending=1
    }

    public enum ErrorHandle
    {
        Throw,
        Continue
    }

    public enum DBAction
    {
        None =0,
        Add,
        Modify,
        Delete,
        Query
    }

    public enum RequestMethod
    {
        POST,
        GET,
        HEAD
    }
}
