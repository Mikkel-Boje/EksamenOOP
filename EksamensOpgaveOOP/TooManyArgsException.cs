using System;

namespace Stregsystemet
{
    class TooManyArgsException : Exception {
        public TooManyArgsException(string commad) : base() {
            Commad = commad;
        }
        public string Commad { get; }
    } 
}