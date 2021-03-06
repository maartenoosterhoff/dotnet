using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Profiling.Internal;

namespace StackExchange.Profiling.Storage
{
    /// <summary>
    /// Empty storage provider for testing, etc.
    /// </summary>
    internal class NullStorage : IAsyncStorage
    {
        public IEnumerable<Guid> List(
            int maxResults,
            DateTime? start = null,
            DateTime? finish = null,
            ListResultsOrder orderBy = ListResultsOrder.Descending) => Enumerable.Empty<Guid>();
        public Task<IEnumerable<Guid>> ListAsync(
            int maxResults,
            DateTime? start = null,
            DateTime? finish = null,
            ListResultsOrder orderBy = ListResultsOrder.Descending) => Task.FromResult(Enumerable.Empty<Guid>());
        public void Save(MiniProfiler profiler) { /* no-op */ }
        public Task SaveAsync(MiniProfiler profiler) => Polyfills.CompletedTask;
        public MiniProfiler Load(Guid id) => null;
        public Task<MiniProfiler> LoadAsync(Guid id) => Task.FromResult((MiniProfiler)null);
        public bool SetUnviewedAfterSave => false;
        public void SetUnviewed(string user, Guid id) { /* no-op */ }
        public Task SetUnviewedAsync(string user, Guid id) => Polyfills.CompletedTask;
        public void SetViewed(string user, Guid id) { /* no-op */ }
        public Task SetViewedAsync(string user, Guid id) => Polyfills.CompletedTask;
        public List<Guid> GetUnviewedIds(string user) => new List<Guid>();
        public Task<List<Guid>> GetUnviewedIdsAsync(string user) => Task.FromResult(new List<Guid>());
    }
}
