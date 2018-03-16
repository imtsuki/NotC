// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-16-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="SyntaxErrorException.cs" company="C">
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
    /// Class SyntaxErrorException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(string message) : base(message)
        {
        }
    }
}
