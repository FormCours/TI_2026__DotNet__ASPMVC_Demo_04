using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCinema.BLL.BusinessExceptions
{
    public class ScreeningException : Exception
    {
        public ScreeningException() { }
        public ScreeningException(string? message) : base(message) { }
    }
    public class ScreeningDateException : ScreeningException
    {
        public ScreeningDateException() : base("La date est invalide") { }
    }
    public class ScreeningMovieException : ScreeningException
    {
        public ScreeningMovieException() : base("Film invalide") { }
    }
}
