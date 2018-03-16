// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-16-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="Symbol.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace C.Parser
{
    /// <summary>
    /// Class Symbol.
    /// </summary>
    public class Symbol
    {
        private static int count = -1;
        private static int NextId()
        {
            count++;
            return count;
        }

        private int id;
        public int Id { get => id; }
        public Symbol()
        {
            this.id = NextId();
        }
    }
}
