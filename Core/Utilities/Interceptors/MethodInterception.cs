
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation) { }
        protected virtual void OnSucces(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSucces = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception e)
            {
                isSucces = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if(isSucces)
                OnSucces(invocation);
            }
            OnAfter(invocation);
        }


    }
}
