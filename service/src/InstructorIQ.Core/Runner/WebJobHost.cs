using System;
using System.Threading;

namespace InstructorIQ.Core.Runner
{
    public class WebJobHost : IDisposable
    {
        private readonly CancellationTokenSource _shutdownTokenSource;
        private readonly WebJobShutdownWatcher _shutdownWatcher;
        private readonly CancellationTokenSource _stoppingTokenSource;
        private bool _disposed;

        public WebJobHost()
        {
            _shutdownTokenSource = new CancellationTokenSource();
            _shutdownWatcher = WebJobShutdownWatcher.Create(_shutdownTokenSource);
            _stoppingTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_shutdownTokenSource.Token);

            // support cancel keys
            Console.CancelKeyPress += OnCancelKeyPress;
        }

        public void RunAndBlock()
        {
            _stoppingTokenSource.Token.WaitHandle.WaitOne();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed)
                return;

            // Running callers might still be using this cancellation token.
            // Mark it canceled but don't dispose of the source while the callers are running.
            // Otherwise, callers would receive ObjectDisposedException when calling token.Register.
            // For now, rely on finalization to clean up _shutdownTokenSource's wait handle (if allocated).
            _shutdownTokenSource.Cancel();

            _stoppingTokenSource.Dispose();
            _shutdownWatcher?.Dispose();

            // free event
            Console.CancelKeyPress -= OnCancelKeyPress;

            _disposed = true;
        }


        private void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _stoppingTokenSource.Cancel();
            e.Cancel = true;
        }
    }
}