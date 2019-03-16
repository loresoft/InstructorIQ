using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Multitenancy
{
    public class TenantContext<TTenant> : IDisposable
    {
        private bool _disposed;

        public TenantContext(TTenant tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException(nameof(tenant));

            Tenant = tenant;
            Properties = new Dictionary<string, object>();
        }

        public string Id { get; } = Guid.NewGuid().ToString();

        public TTenant Tenant { get; }

        public IDictionary<string, object> Properties { get; }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                foreach (var prop in Properties)
                    TryDisposeProperty(prop.Value as IDisposable);

                TryDisposeProperty(Tenant as IDisposable);
            }

            _disposed = true;
        }

        private void TryDisposeProperty(IDisposable obj)
        {
            if (obj == null)
                return;

            try
            {
                obj.Dispose();
            }
            catch (ObjectDisposedException)
            {

            }
        }
    }
}