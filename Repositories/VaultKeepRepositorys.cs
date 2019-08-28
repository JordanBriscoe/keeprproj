using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public VaultKeep AddKeepToVault(VaultKeep VaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultKeeps (keepId, vaultId, userId)
          VALUES (@keepId, @vaultId, @userId);
          SELECT LAST_INSERT_ID();
          ", VaultKeep);
      VaultKeep.Id = id;
      return VaultKeep;
    }

    internal IEnumerable<VaultKeep> GetKeepsByVaults(int VaultId, string UserId)
    {
      string query = @"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE (vaultId = @vaultId AND vk.userId = @userId);
        ";
      return _db.Query<VaultKeep>(query, new { VaultId, UserId });
    }
  }
}