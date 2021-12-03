using System;
using System.Collections.Generic;

namespace Backups.Entities.RestorePointModule
{
    public interface IRestorePoint
    {
        DateTime Time { get; }
        string Name { get; }
        IEnumerable<IStorage> GetStorages();
        bool ContainsJobObject(string name);
        void AddStorage(IStorage storage);
    }
}