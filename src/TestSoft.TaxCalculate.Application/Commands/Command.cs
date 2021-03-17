using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TestSoft.TaxCalculate.Application.CommandResults;

namespace TestSoft.TaxCalculate.Application.Commands
{
    public abstract class Command<TCommand> : IRequest<CommandResult> where TCommand : Command<TCommand>
    {
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }
        public bool Invalid => !Valid;

        protected bool CommandIsValid => Valid = ValidationResult.IsValid;

        protected void InsertValidation(TCommand command, AbstractValidator<TCommand> validator) 
            => ValidationResult = validator.Validate(command);

        public abstract bool Validate();
    }
}