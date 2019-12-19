using System.ComponentModel.DataAnnotations;

namespace SimpleLoginReg
{
    public class IndexViewModel
    {
        public RegUser NewUser { get; set; }
        public LogUser LoggedUser { get; set; }
    }
}