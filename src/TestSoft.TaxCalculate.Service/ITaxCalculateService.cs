using System.Threading.Tasks;

namespace TestSoft.TaxCalculate.Service
{
    public interface ITaxCalculateService
    {
        Task<double?> GetTaxRate();
    }
}