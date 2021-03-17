using FluentValidation;

namespace TestSoft.TaxCalculate.Application.Commands.TaxCalculate
{
    public class TaxCalculateCommand : Command<TaxCalculateCommand>
    {
        public TaxCalculateCommand(double value, int month)
        {
            Value = value;
            Month = month;
        }

        public double Value { get; }
        public int Month { get; }
        public override bool Validate()
        {
            InsertValidation(this, new TaxCalculateCommandValidator());
            return CommandIsValid;
        }
    }

    internal sealed class TaxCalculateCommandValidator : AbstractValidator<TaxCalculateCommand>
    {
        internal TaxCalculateCommandValidator()
        {
            RuleFor(e => e.Value)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(e => e.Month)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}