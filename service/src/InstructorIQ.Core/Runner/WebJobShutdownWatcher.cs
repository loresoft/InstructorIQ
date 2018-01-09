using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading;

namespace InstructorIQ.Core.Runner
{
    public sealed class WebJobShutdownWatcher : IDisposable
    {
        private readonly string _shutdownFile;
        private readonly bool _ownsCancellationTokenSource;

        private CancellationTokenSource _cts;
        private FileSystemWatcher _watcher;

        public WebJobShutdownWatcher()
            : this(new CancellationTokenSource(), true)
        {
        }

        private WebJobShutdownWatcher(CancellationTokenSource cancellationTokenSource, bool ownsCancellationTokenSource)
        {
            // http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/#.U3aIXRFOVaQ
            // Antares will set this file to signify shutdown
            _shutdownFile = Environment.GetEnvironmentVariable("WEBJOBS_SHUTDOWN_FILE");
            if (_shutdownFile == null)
            {
                // If env var is not set, then no shutdown support
                return;
            }

            // Setup a file system watcher on that file's directory to know when the file is created
            string directoryName = Path.GetDirectoryName(_shutdownFile);
            try
            {
                // FileSystemWatcher throws an argument exception if the part of
                // the directory name does not exist
                _watcher = new FileSystemWatcher(directoryName);
            }
            catch (ArgumentException)
            {
                // The path is invalid
                return;
            }

            _watcher.Created += OnChanged;
            _watcher.Changed += OnChanged;
            _watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastWrite;
            _watcher.IncludeSubdirectories = false;
            _watcher.EnableRaisingEvents = true;

            _cts = cancellationTokenSource;
            _ownsCancellationTokenSource = ownsCancellationTokenSource;
        }

        public CancellationToken Token => _cts?.Token ?? CancellationToken.None;

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            var fileName = Path.GetFileName(_shutdownFile);
            if (e.FullPath.IndexOf(fileName, StringComparison.OrdinalIgnoreCase) < 0)
                return;

            // Found the file mark this WebJob as finished
            _cts?.Cancel();
        }

        public void Dispose()
        {
            if (_watcher == null)
                return;

            var cts = _cts;
            if (cts != null && _ownsCancellationTokenSource)
            {
                // Null out the field to prevent a race condition in OnChanged above.
                _cts = null;
                cts.Dispose();
            }

            _watcher.Dispose();
            _watcher = null;
        }

        internal static WebJobShutdownWatcher Create(CancellationTokenSource cancellationTokenSource)
        {
            var watcher = new WebJobShutdownWatcher(cancellationTokenSource, false);
            if (watcher._watcher != null)
                return watcher;

            watcher.Dispose();
            return null;
        }
    }
}
