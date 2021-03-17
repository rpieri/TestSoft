using TestSoft.TaxCalculate.Application.Commands.TaxCalculate;

namespace TestSof.TaxCalculate.API.ViewModels
{
    public class TaxCalculateViewModel
    {
        public double Valor { get; set; }
        public int Meses { get; set; }

        public TaxCalculateCommand Mapping()
            => new TaxCalculateCommand(Valor, Meses);
    }
}