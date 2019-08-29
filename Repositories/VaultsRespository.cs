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

    // Gets all Vaults from the database
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public Vault GetbyId(string Id)
    {
      string query = "SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(query, new { Id });
    }
    // test push still works
    public Vault CreateVault(Vault vault)
    {
      _db.Execute("INSERT INTO vaults (name, description) VALUES(@Name, @Description)", vault);
      return vault;
    }

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