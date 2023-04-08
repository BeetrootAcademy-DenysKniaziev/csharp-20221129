using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Controller.Tests
{
    public class TestSession : ISession
    {
        private Dictionary<string, byte[]> _store = new Dictionary<string, byte[]>();

        public string Id { get; } = Guid.NewGuid().ToString();

        public bool IsAvailable { get; } = true;

        public IEnumerable<string> Keys { get { return _store.Keys; } }

        public void Clear()
        {
            _store.Clear();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public void Remove(string key)
        {
            _store.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            _store[key] = value;
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return _store.TryGetValue(key, out value);
        }
    }
}
