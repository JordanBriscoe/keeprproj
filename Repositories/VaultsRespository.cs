using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault CreateVault(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (name, description, userId)VALUES(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();", vault);
      vault.Id = id;
      return vault;
    }

    // Gets all Vaults from the database
    public IEnumerable<Vault> GetVaultsByUser(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userId", new { userId });
    }

    // public Vault GetbyId(string Id)
    // {
    //   string query = "SELECT * FROM vaults WHERE id = @Id";
    //   return _db.QueryFirstOrDefault<Vault>(query, new { Id });
    // }
    // test push still works

    //TODO Stretch Goal is to create an EDIT

    public bool DeleteVault(string Id)
    {
      int success = _db.Execute("DELETE FROM  vaults WHERE id = @Id", new { Id });
      return success > 0;
    }

    public string AddVaultToKeep(string vaultId, int keepId)
    {
      int success = _db.Execute(@"
      INSERT INTO vaultKeeps (vaultId, keepId)
      VALUES (@vaultId, @keepId)",
      new
      {
        vaultId,
        keepId
      });
      return success > 0 ? "success!" : "something has gone terribly wrong";
    }


    // TODO FIX the KEEPID at the bottom
    // internal IEnumerable<Vault> GetVaultsByKeepId(int keepId)
    // {
    //   string query = @"
    //   SELECT * FROM vaultkeeps vk
    //   INNER JOIN vaults v ON v.id = vk.vaultId
    //   WHERE keepID = @keepId;
    //   ";
    //   return _db.Query<Vault>(query, new Vault { keepId });
    // }
  }
}