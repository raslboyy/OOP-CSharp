using System;
using System.Collections.Generic;

namespace Backups.Entities.RestorePointModule
{
    public interface IRestorePoint
    {
        DateTime Time { get; }
        string Name { get; }
        IEnumerable<IStorage> GetStorages();
        bool Contains(string name);
    }
}