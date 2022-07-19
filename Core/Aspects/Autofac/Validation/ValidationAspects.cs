using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validaton.FluentValidation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspects : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspects(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(AspectMessages.WrongValidationType);

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
                ValidationTool.Validation(validator, entity);
        }
    }
}
